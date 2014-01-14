﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using LWDock.Forms;
using System.Drawing.Drawing2D;

namespace LWDock
{
    public partial class DockFrame : DockElementContainerFrame
    {
        private string folder;
        private int showTimeout, maxX, centerX, yPos;
        private Timer timer;
        public bool alwaysOnTop;

        public DockFrame(String folder) : base(folder, Config.getInstance().maxPopups)
        {
            InitializeComponent();
            Config.getInstance().path = folder;
            this.folder = folder;
            this.init();
            Config.getInstance().Changed += this.setttingsUpdated;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.TransparencyKey = Color.Black;
            //this.BackgroundImage = new System.Drawing.Bitmap("bg.png");
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private static IEnumerable<string> getSubFileFolders(String folder)
        {
            return Directory.GetFiles(folder).Union(Directory.GetDirectories(folder));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (WAPI.getCursorPos().Y > Screen.PrimaryScreen.Bounds.Height - 5)
            {
                if (showTimeout < 25) showTimeout++;
                else
                {
                    showTimeout = 0;
                    WAPI.SetForegroundWindow(this.Handle);
                }
            }
            else showTimeout = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(e.X + this.Location.X, e.Y + this.Location.Y);
            }
        }

        private void init()
        {
            base.init(this.folder);
            if (this.timer != null) this.timer.Stop();
            this.timer = new Timer();
            this.timer.Interval = 1;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
            this.updatePositions();
            this.Location = new Point(centerX, yPos);

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.init();
        }

        private void chooseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.folder = dialog.SelectedPath;
                Config.getInstance().path = this.folder;
                Config.getInstance().save();
                this.init();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.init();

            //TODO: Check if there's any way to use this
            /*GraphicsPath path = new GraphicsPath();
            foreach (DockElement element in this.elements)
            {
                path.AddRectangle(element.button.Bounds);
                path.AddRectangle(element.label.Bounds);
            }
            Region region = new Region(path);  
            this.Region = region;*/
        }

        private void move()
        {
            int x = this.Location.X;

            if (Math.Abs(centerX - x) < 30) x = centerX;
            else if (maxX - x < 20) x = maxX;
            else if (x < 20) x = 0;
            else x = Math.Min(Math.Max(this.Location.X, 0), maxX);

            this.Location = new Point(x, this.yPos);
        }

        protected override void OnMove(EventArgs e)
        {
            this.move();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.updatePositions();
        }

        private void updatePositions()
        {
            this.maxX = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
            this.centerX = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Size.Width / 2;
            this.yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
        }

        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == WAPI.WM_MOVING)
            {
                WAPI.RECTAPI rc = (WAPI.RECTAPI)Marshal.PtrToStructure(m.LParam, typeof(WAPI.RECTAPI));
                Screen scr = Screen.PrimaryScreen;

                Rectangle rect = Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom);

                rect.X = Math.Min(Math.Max(rect.X, 0), maxX);

                rc.left = rect.Left;
                rc.right = rect.Right;
                rc.bottom = scr.WorkingArea.Bottom;
                rc.top = scr.WorkingArea.Bottom - this.Height;

                Marshal.StructureToPtr(rc, m.LParam, false);
            }
            base.WndProc(ref m);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm form = new ConfigForm();
            form.ShowDialog(this);
        }

        private void setttingsUpdated(object sender, EventArgs args)
        {
            this.TopMost = Config.getInstance().keepOnTop;
            foreach (DockElement element in elements)
            {
                element.closePopup();
                element.maxNesting = Config.getInstance().maxPopups;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Config.getInstance().save();
        }

        protected override bool isPopup()
        {
            return false;
        }
    }
}