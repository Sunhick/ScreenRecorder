namespace ScreenRecorder
{
    partial class AppSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.saveLbl = new System.Windows.Forms.Label();
            this.saveLocBox = new System.Windows.Forms.TextBox();
            this.settingsTab = new System.Windows.Forms.TabControl();
            this.avSettings = new System.Windows.Forms.TabPage();
            this.miscTab = new System.Windows.Forms.TabPage();
            this.OpacityBar = new System.Windows.Forms.TrackBar();
            this.opacityLbl = new System.Windows.Forms.Label();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.settingsTab.SuspendLayout();
            this.avSettings.SuspendLayout();
            this.miscTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(573, 582);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Frames Per sec";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Location = new System.Drawing.Point(168, 25);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // saveLbl
            // 
            this.saveLbl.AutoSize = true;
            this.saveLbl.Location = new System.Drawing.Point(43, 77);
            this.saveLbl.Name = "saveLbl";
            this.saveLbl.Size = new System.Drawing.Size(79, 13);
            this.saveLbl.TabIndex = 7;
            this.saveLbl.Text = "Save Location:";
            // 
            // saveLocBox
            // 
            this.saveLocBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.saveLocBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saveLocBox.Location = new System.Drawing.Point(168, 77);
            this.saveLocBox.Name = "saveLocBox";
            this.saveLocBox.Size = new System.Drawing.Size(325, 20);
            this.saveLocBox.TabIndex = 8;
            // 
            // settingsTab
            // 
            this.settingsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTab.Controls.Add(this.avSettings);
            this.settingsTab.Controls.Add(this.miscTab);
            this.settingsTab.Location = new System.Drawing.Point(0, 0);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(652, 576);
            this.settingsTab.TabIndex = 12;
            // 
            // avSettings
            // 
            this.avSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.avSettings.Controls.Add(this.label1);
            this.avSettings.Controls.Add(this.numericUpDown1);
            this.avSettings.Controls.Add(this.saveLocBox);
            this.avSettings.Controls.Add(this.saveLbl);
            this.avSettings.Location = new System.Drawing.Point(4, 22);
            this.avSettings.Name = "avSettings";
            this.avSettings.Padding = new System.Windows.Forms.Padding(3);
            this.avSettings.Size = new System.Drawing.Size(644, 550);
            this.avSettings.TabIndex = 0;
            this.avSettings.Text = "Video Audio Settings";
            // 
            // miscTab
            // 
            this.miscTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.miscTab.Controls.Add(this.OpacityBar);
            this.miscTab.Controls.Add(this.opacityLbl);
            this.miscTab.Controls.Add(this.langComboBox);
            this.miscTab.Controls.Add(this.label2);
            this.miscTab.Location = new System.Drawing.Point(4, 22);
            this.miscTab.Name = "miscTab";
            this.miscTab.Padding = new System.Windows.Forms.Padding(3);
            this.miscTab.Size = new System.Drawing.Size(644, 550);
            this.miscTab.TabIndex = 1;
            this.miscTab.Text = "General Settings";
            // 
            // OpacityBar
            // 
            this.OpacityBar.Location = new System.Drawing.Point(107, 80);
            this.OpacityBar.Name = "OpacityBar";
            this.OpacityBar.Size = new System.Drawing.Size(275, 42);
            this.OpacityBar.TabIndex = 13;
            // 
            // opacityLbl
            // 
            this.opacityLbl.AutoSize = true;
            this.opacityLbl.Location = new System.Drawing.Point(25, 80);
            this.opacityLbl.Name = "opacityLbl";
            this.opacityLbl.Size = new System.Drawing.Size(46, 13);
            this.opacityLbl.TabIndex = 14;
            this.opacityLbl.Text = "Opacity:";
            // 
            // langComboBox
            // 
            this.langComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.langComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Items.AddRange(new object[] {
            "en-US",
            "es",
            "zh"});
            this.langComboBox.Location = new System.Drawing.Point(117, 24);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(121, 21);
            this.langComboBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Language:";
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.settingsTab);
            this.DoubleBuffered = true;
            this.Name = "AppSettings";
            this.Size = new System.Drawing.Size(656, 609);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.settingsTab.ResumeLayout(false);
            this.avSettings.ResumeLayout(false);
            this.avSettings.PerformLayout();
            this.miscTab.ResumeLayout(false);
            this.miscTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label saveLbl;
        private System.Windows.Forms.TextBox saveLocBox;
        private System.Windows.Forms.TabControl settingsTab;
        private System.Windows.Forms.TabPage avSettings;
        private System.Windows.Forms.TabPage miscTab;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.Label opacityLbl;
    }
}
