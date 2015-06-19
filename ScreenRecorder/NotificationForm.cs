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
using System.Windows.Forms;

#endregion

namespace ScreenRecorder
{
    /// <summary>
    ///     Notification form
    /// </summary>
    /// <returns>Form</returns>
    public partial class NotificationForm : Form
    {
        ///// <summary>
        ///// Animation timer
        ///// </summary>
        //Timer animationTimer;

        /// <summary>
        ///     My appearing
        /// </summary>
        private bool myAppearing;

        /// <summary>
        ///     Wait timer
        /// </summary>
        private Timer waitTimer;

        /// <summary>
        ///     Initializes a new instance of the NotificationForm class.
        /// </summary>
        public NotificationForm()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            Load += new EventHandler(OnNotifierLoad);
        }

        /// <summary>
        ///     On notifier load
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnNotifierLoad(object sender, EventArgs e)
        {
            //Opacity = 0;

            //animationTimer = new Timer { Interval = 100 };
            myAppearing = true;
            //animationTimer.Tick += new EventHandler(animationTimer_Tick);
            //animationTimer.Start();

            waitTimer = new Timer {Interval = 700 /*wait for 0.7secs*/};
            waitTimer.Tick += new EventHandler(waitTimer_Tick);
            waitTimer.Start();

            Show();
        }

        /// <summary>
        ///     Wait timer tick
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void waitTimer_Tick(object sender, EventArgs e)
        {
            waitTimer.Stop();
            myAppearing = false;

            Close();
            // animationTimer.Start();
        }

        /// <summary>
        ///     Animation timer tick
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (myAppearing)
            {
                if (Opacity == 1)
                {
                    //animationTimer.Stop();
                }

                Opacity += 0.05;
            }
            else
            {
                if (Opacity == 0)
                {
                    Close();
                    //this.Hide();
                }

                Opacity -= 0.05;
            }
        }

        /// <summary>
        ///     Popup
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="location">Location</param>
        public void Popup(string message)
        {
            userMsgBox.Text = message;
            //this.Location = location;

            //this.Show();
            Application.Run(this);

            //animationTimer.Dispose();
        }
    } // class NotificationForm
} // namespace ScreenRecorder