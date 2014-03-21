#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : Notification.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion
#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace ScreenRecorder
{
    /// <summary>
    /// Notification form
    /// </summary>
    public partial class NotificationForm : Form
    {
        /// <summary>
        /// Animation timer
        /// </summary>
        Timer animationTimer;
        /// <summary>
        /// Wait timer
        /// </summary>
        Timer waitTimer;
        /// <summary>
        /// My appearing
        /// </summary>
        bool myAppearing;

        /// <summary>
        /// Initializes a new instance of the NotificationForm class.
        /// </summary>
        public NotificationForm()
        {
            InitializeComponent();

            this.userMsgBox.SelectionAlignment = HorizontalAlignment.Center;
            this.ShowInTaskbar = false;
            this.Load  += new EventHandler(OnNotifierLoad);
        }

        /// <summary>
        /// On notifier load
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnNotifierLoad(object sender, EventArgs e)
        {
            Opacity = 0;

            animationTimer = new Timer { Interval = 100 };
            myAppearing = true;
            animationTimer.Tick += new EventHandler(animationTimer_Tick);
            animationTimer.Start();

            waitTimer = new Timer { Interval = 2500 /*wait for 2secs*/ };
            waitTimer.Tick += new EventHandler(waitTimer_Tick);
            waitTimer.Start();
        }

        /// <summary>
        /// Wait timer tick
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        void waitTimer_Tick(object sender, EventArgs e)
        {
            waitTimer.Stop();
            myAppearing = false;
            animationTimer.Start();
        }

        /// <summary>
        /// Animation timer tick
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        void animationTimer_Tick(object sender, EventArgs e)
        {
            if (myAppearing)
            {
                if (Opacity == 1)
                {
                    animationTimer.Stop();
                }

                Opacity += 0.05;
            }
            else
            {
                if (Opacity == 0)
                {
                   // this.Close();
                    this.Hide();
                }

                Opacity -= 0.05;
            }
        }

        /// <summary>
        /// Popup
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="location">Location</param>
        public void Popup(string message, Point location)
        {
            this.userMsgBox.Text = message;
            this.Location = location;

            //this.Show();
            Application.Run(this);
        }
    } // class NotificationForm
} // namespace ScreenRecorder
