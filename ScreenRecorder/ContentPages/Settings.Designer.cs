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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.saveBtn = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.OpacityBar = new System.Windows.Forms.TrackBar();
            this.opacityLbl = new System.Windows.Forms.Label();
            this.saveLbl = new System.Windows.Forms.Label();
            this.saveLocBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(157, 460);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.save_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Control;
            this.monthCalendar1.Location = new System.Drawing.Point(35, 74);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.TitleForeColor = System.Drawing.SystemColors.Control;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Frames Per sec";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(280, 268);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // OpacityBar
            // 
            this.OpacityBar.Location = new System.Drawing.Point(280, 319);
            this.OpacityBar.Name = "OpacityBar";
            this.OpacityBar.Size = new System.Drawing.Size(265, 42);
            this.OpacityBar.TabIndex = 5;
            this.OpacityBar.Scroll += new System.EventHandler(this.Opacity_Scroll);
            // 
            // opacityLbl
            // 
            this.opacityLbl.AutoSize = true;
            this.opacityLbl.Location = new System.Drawing.Point(188, 319);
            this.opacityLbl.Name = "opacityLbl";
            this.opacityLbl.Size = new System.Drawing.Size(46, 13);
            this.opacityLbl.TabIndex = 6;
            this.opacityLbl.Text = "Opacity:";
            // 
            // saveLbl
            // 
            this.saveLbl.AutoSize = true;
            this.saveLbl.Location = new System.Drawing.Point(155, 372);
            this.saveLbl.Name = "saveLbl";
            this.saveLbl.Size = new System.Drawing.Size(79, 13);
            this.saveLbl.TabIndex = 7;
            this.saveLbl.Text = "Save Location:";
            // 
            // saveLocBox
            // 
            this.saveLocBox.Location = new System.Drawing.Point(280, 369);
            this.saveLocBox.Name = "saveLocBox";
            this.saveLocBox.Size = new System.Drawing.Size(265, 20);
            this.saveLocBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Language:";
            // 
            // langComboBox
            // 
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Items.AddRange(new object[] {
            "en-US",
            "es",
            "zh"});
            this.langComboBox.Location = new System.Drawing.Point(445, 41);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(121, 21);
            this.langComboBox.TabIndex = 10;
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.langComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveLocBox);
            this.Controls.Add(this.saveLbl);
            this.Controls.Add(this.opacityLbl);
            this.Controls.Add(this.OpacityBar);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AppSettings";
            this.Size = new System.Drawing.Size(1226, 848);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.Label opacityLbl;
        private System.Windows.Forms.Label saveLbl;
        private System.Windows.Forms.TextBox saveLocBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox langComboBox;
    }
}
