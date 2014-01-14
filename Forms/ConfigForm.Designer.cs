﻿namespace LWDock.Forms
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maxPopupsLabel = new System.Windows.Forms.Label();
            this.maxPopupsNumber = new System.Windows.Forms.NumericUpDown();
            this.keepOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.noPopupsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxPopupsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // maxPopupsLabel
            // 
            this.maxPopupsLabel.AutoSize = true;
            this.maxPopupsLabel.Location = new System.Drawing.Point(12, 62);
            this.maxPopupsLabel.Name = "maxPopupsLabel";
            this.maxPopupsLabel.Size = new System.Drawing.Size(185, 13);
            this.maxPopupsLabel.TabIndex = 5;
            this.maxPopupsLabel.Text = "Max nested popups (-1 means infinite)";
            // 
            // maxPopupsNumber
            // 
            this.maxPopupsNumber.Location = new System.Drawing.Point(228, 60);
            this.maxPopupsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxPopupsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.maxPopupsNumber.Name = "maxPopupsNumber";
            this.maxPopupsNumber.Size = new System.Drawing.Size(43, 20);
            this.maxPopupsNumber.TabIndex = 4;
            // 
            // keepOnTopCheckBox
            // 
            this.keepOnTopCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.keepOnTopCheckBox.Location = new System.Drawing.Point(12, 12);
            this.keepOnTopCheckBox.Name = "keepOnTopCheckBox";
            this.keepOnTopCheckBox.Size = new System.Drawing.Size(259, 18);
            this.keepOnTopCheckBox.TabIndex = 3;
            this.keepOnTopCheckBox.Text = "Keep always on top";
            this.keepOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(196, 86);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(115, 86);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noPopupsCheckBox
            // 
            this.noPopupsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.noPopupsCheckBox.Location = new System.Drawing.Point(12, 36);
            this.noPopupsCheckBox.Name = "noPopupsCheckBox";
            this.noPopupsCheckBox.Size = new System.Drawing.Size(259, 18);
            this.noPopupsCheckBox.TabIndex = 8;
            this.noPopupsCheckBox.Text = "Do not open popups";
            this.noPopupsCheckBox.UseVisualStyleBackColor = true;
            this.noPopupsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.noPopupsCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.maxPopupsLabel);
            this.Controls.Add(this.maxPopupsNumber);
            this.Controls.Add(this.keepOnTopCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.maxPopupsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label maxPopupsLabel;
        private System.Windows.Forms.NumericUpDown maxPopupsNumber;
        private System.Windows.Forms.CheckBox keepOnTopCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox noPopupsCheckBox;

    }
}