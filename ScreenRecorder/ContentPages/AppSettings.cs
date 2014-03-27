#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : Settings.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion

#region Using directives
using ScreenRecorder.ContentPages;
using ScreenRecorder.Properties;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ScreenRecorder.Hooks;
#endregion

namespace ScreenRecorder.ContentPages
{
    /// <summary>
    /// App settings
    /// </summary>
    public partial class AppSettings : UserControl, IContentPage
    {
        /// <summary>
        /// Initializes a new instance of the AppSettings class.
        /// </summary>
        public AppSettings()
        {
            InitializeComponent();
            OpacityBar.Maximum = 10;
            OpacityBar.Minimum = 1;
            OpacityBar.Value = 9;

            ReadUserSettings();
        }

        /// <summary>
        /// Read config
        /// </summary>
        private void ReadUserSettings()
        {
            numericUpDown1.Value = Settings.Default.FramesPerSec;
            saveLocBox.Text = Settings.Default.BitmapTempLoc;
            langComboBox.SelectedItem = (string)Settings.Default.Language;
            voutLocBox.Text = Settings.Default.VideoLoc;
            videoTypeBox.Text = Settings.Default.VideoType;

            HookParser parser = new HookParser();
            List<HookData> data = parser.Parse();

            foreach (HookData item in data)
            {
                videoTypeBox.Items.Add(item.HookID);
            }
        }

        /// <summary>
        /// Opacity scroll
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void Opacity_Scroll(object sender, EventArgs e)
        {
            int v = this.OpacityBar.Value;
        }

        /// <summary>
        /// Save click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void save_Click(object sender, EventArgs e)
        {
            Settings.Default.FramesPerSec = (int)numericUpDown1.Value;
            Settings.Default.BitmapTempLoc = saveLocBox.Text;
            Settings.Default.Language = langComboBox.SelectedItem as string;
            Settings.Default.VideoLoc = voutLocBox.Text;
            Settings.Default.VideoType = videoTypeBox.SelectedItem as string;

            //save all the user settings.
            Settings.Default.Save();

            //MessageBox.Show("Application must be restarted inorder to apply the changes", "Restart", 
            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 
            //    MessageBoxOptions.ServiceNotification);
            if (MessageBox.Show("Application must be restarted inorder to apply the changes", "Restart", "Cancel") == YesNo.Yes)
            {
                Application.Restart();
            }
            //Settings.Default.Opacity = (decimal)OpacityBar.Value/10;
        }

        /// <summary>
        /// About us 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutusBtn_Click(object sender, EventArgs e)
        {
            AboutBox aboutUs = new AboutBox();
            aboutUs.ShowDialog();
        }
    } // class AppSettings
} // namespace ScreenRecorder
