// This file is part of ScreenRecorder
//  
// ScreenRecorder  is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// ScreenRecorder is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with ScreenRecorder.  If not, see <http://www.gnu.org/licenses/>.

#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScreenRecorder.Hooks;
using ScreenRecorder.Properties;

#endregion

namespace ScreenRecorder.ContentPages
{
    /// <summary>
    ///     App settings
    /// </summary>
    public partial class AppSettings : UserControl, IContentPage
    {
        /// <summary>
        ///     Initializes a new instance of the AppSettings class.
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
        ///     Read config
        /// </summary>
        private void ReadUserSettings()
        {
            numericUpDown1.Value = Settings.Default.FramesPerSec;
            saveLocBox.Text = Settings.Default.BitmapTempLoc;
            langComboBox.SelectedItem = (string) Settings.Default.Language;
            voutLocBox.Text = Settings.Default.VideoLoc;
            videoTypeBox.Text = Settings.Default.VideoType;

            var parser = new HookParser();
            var data = parser.Parse();

            foreach (var item in data)
            {
                videoTypeBox.Items.Add(item.HookId);
            }
        }

        /// <summary>
        ///     Opacity scroll
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void Opacity_Scroll(object sender, EventArgs e)
        {
            var v = OpacityBar.Value;
        }

        /// <summary>
        ///     Save click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void save_Click(object sender, EventArgs e)
        {
            Settings.Default.FramesPerSec = (int) numericUpDown1.Value;
            Settings.Default.BitmapTempLoc = saveLocBox.Text;
            Settings.Default.Language = langComboBox.SelectedItem as string;
            Settings.Default.VideoLoc = voutLocBox.Text;
            Settings.Default.VideoType = videoTypeBox.SelectedItem as string;

            //save all the user settings.
            Settings.Default.Save();

            //MessageBox.Show("Application must be restarted inorder to apply the changes", "Restart", 
            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 
            //    MessageBoxOptions.ServiceNotification);
            if (MessageBox.Show("Application must be restarted inorder to apply the changes", "Restart", "Cancel") ==
                YesNo.Yes)
            {
                Application.Restart();
            }
            //Settings.Default.Opacity = (decimal)OpacityBar.Value/10;
        }

        /// <summary>
        ///     About us
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutusBtn_Click(object sender, EventArgs e)
        {
            var aboutUs = new AboutBox();
            aboutUs.ShowDialog();
        }
    } // class AppSettings
} // namespace ScreenRecorder