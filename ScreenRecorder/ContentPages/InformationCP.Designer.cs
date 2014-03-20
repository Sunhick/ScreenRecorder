using System.Drawing;
namespace ScreenRecorderMP
{
    partial class InformationCP
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
            this.infoTab = new System.Windows.Forms.TabControl();
            this.videoTab = new System.Windows.Forms.TabPage();
            this.audioTab = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.infoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.videoTab);
            this.infoTab.Controls.Add(this.audioTab);
            this.infoTab.Controls.Add(this.tabPage1);
            this.infoTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTab.Location = new System.Drawing.Point(0, 0);
            this.infoTab.Name = "infoTab";
            this.infoTab.SelectedIndex = 0;
            this.infoTab.ShowToolTips = true;
            this.infoTab.Size = new System.Drawing.Size(1226, 848);
            this.infoTab.TabIndex = 0;
            // 
            // videoTab
            // 
            this.videoTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.videoTab.ForeColor = System.Drawing.SystemColors.Highlight;
            this.videoTab.Location = new System.Drawing.Point(4, 24);
            this.videoTab.Name = "videoTab";
            this.videoTab.Padding = new System.Windows.Forms.Padding(3);
            this.videoTab.Size = new System.Drawing.Size(1218, 820);
            this.videoTab.TabIndex = 0;
            this.videoTab.Text = "Video Codec";
            // 
            // audioTab
            // 
            this.audioTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.audioTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.audioTab.Location = new System.Drawing.Point(4, 24);
            this.audioTab.Name = "audioTab";
            this.audioTab.Padding = new System.Windows.Forms.Padding(3);
            this.audioTab.Size = new System.Drawing.Size(1218, 820);
            this.audioTab.TabIndex = 1;
            this.audioTab.Text = "Audio Codec";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1218, 820);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "About ScreenRecorder";
            // 
            // InformationCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.infoTab);
            this.DoubleBuffered = true;
            this.Name = "InformationCP";
            this.Size = new System.Drawing.Size(1226, 848);
            this.infoTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl infoTab;
        private System.Windows.Forms.TabPage videoTab;
        private System.Windows.Forms.TabPage audioTab;
        private System.Windows.Forms.TabPage tabPage1;

    }
}
