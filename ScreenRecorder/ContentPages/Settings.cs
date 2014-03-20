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
#endregion

namespace ScreenRecorder
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
            ReadConfig();
        }

        /// <summary>
        /// Read config
        /// </summary>
        private void ReadConfig()
        {
            numericUpDown1.Value = Settings.Default.FramesPerSec;
        }

        /// <summary>
        /// Opacity scroll
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void Opacity_Scroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Save click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void save_Click(object sender, EventArgs e)
        {
            Settings.Default.FramesPerSec = (int)numericUpDown1.Value;
            Settings.Default.SaveLocation = saveLocBox.Text;
            //Settings.Default.Opacity = (decimal)OpacityBar.Value/10;
        }
    } // class AppSettings
} // namespace ScreenRecorder
