﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LWDock.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            this.maxPopupsNumber.Value = Config.getInstance().maxPopups;
            this.keepOnTopCheckBox.Checked = Config.getInstance().keepOnTop;
            this.noPopupsCheckBox.Checked = Config.getInstance().maxPopups == 0;
            this.foldersFirstCheck.Checked = Config.getInstance().foldersFirst;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Config.getInstance().maxPopups = this.noPopupsCheckBox.Checked ? 0 : (int)this.maxPopupsNumber.Value;
            Config.getInstance().keepOnTop = this.keepOnTopCheckBox.Checked;
            Config.getInstance().foldersFirst = this.foldersFirstCheck.Checked;
            Config.getInstance().OnChanged();
            Config.getInstance().save();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.maxPopupsNumber.Enabled = !this.noPopupsCheckBox.Checked;
            this.maxPopupsLabel.Enabled = !this.noPopupsCheckBox.Checked;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Config.getInstance().resetDefaults();
            this.maxPopupsNumber.Value = Config.getInstance().maxPopups;
            this.keepOnTopCheckBox.Checked = Config.getInstance().keepOnTop;
            this.noPopupsCheckBox.Checked = Config.getInstance().maxPopups == 0;
            this.foldersFirstCheck.Checked = Config.getInstance().foldersFirst;
        }
    }
}
