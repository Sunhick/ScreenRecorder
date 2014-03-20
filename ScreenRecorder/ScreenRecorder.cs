#region File Header
/*[ Compilation unit ----------------------------------------------------------
 
   Component       : ScreenRecorderMP
 
   Name            : ScreenRecorder.cs
 
  Author           : Sunil
 
-----------------------------------------------------------------------------*/
/*] END */
#endregion
#region Using directives
using ScreenRecorder;
using ScreenRecorder.Codecs;
using ScreenRecorder.ContentPages;
using ScreenRecorder.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace ScreenRecorderMP
{
    /// <summary>
    /// Screen recorder MP
    /// </summary>
    public partial class ScreenRecorder : Form
    {
        /// <summary>
        /// Content pages
        /// </summary>
        List<IContentPage> contentPages = new List<IContentPage>();

        /// <summary>
        /// encoder
        /// </summary>
        AnimatedGifEncoder encoder = new AnimatedGifEncoder();

        /// <summary>
        /// Last point
        /// </summary>
        private Point lastPoint;

        /// <summary>
        /// Save loc
        /// </summary>
        string saveLoc = string.Empty;

        ///// <summary>
        ///// Index
        ///// </summary>
        //private int index = 1;

        /// <summary>
        /// Initializes a new instance of the ScreenRecorderMP class.
        /// </summary>
        public ScreenRecorder()
        {
            InitializeComponent();
            ReadAppSettings();
            InitCP();
        }
        
        /// <summary>
        /// Read app settings
        /// </summary>
        private void ReadAppSettings()
        {
            //this.Opacity = (double)Settings.Default.Opacity;
        }

        /// <summary>
        /// Init CP
        /// </summary>
        private void InitCP()
        {
            contentPages.Add(new InformationCP());
            contentPages.Add(new AppSettings());
        }

        /// <summary>
        /// Close btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            SaveConfig();
            this.Close();
        }

        /// <summary>
        /// Save config
        /// </summary>
        private void SaveConfig()
        {
            Settings.Default.Save();
        }

        /// <summary>
        /// Maximum btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                //this.maxBtn.Image = Resources.MaximizePlus;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                //this.maxBtn.Image = Resources.MaximizeMinus;
            }
        }

        /// <summary>
        /// Minimum btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// On mouse down
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                lastPoint = new Point(e.X, e.Y);
                this.Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// Wnd proc for handling form resize
        /// </summary>
        /// <param name="m">M</param>
        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;
            const UInt32 HTBOTTOMRIGHT = 17;
            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);
                Rectangle hitBox = new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                if (hitBox.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    handled = true;
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }

        /// <summary>
        /// On mouse move
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - lastPoint.X, p2.Y - lastPoint.Y);

                this.Location = p3;
            }
        }

        /// <summary>
        /// On mouse up
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Info btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void infoBtn_Click(object sender, EventArgs e)
        {
            ActivatePage(contentPages[0]);
        }

        /// <summary>
        /// Activate page
        /// </summary>
        /// <param name="page">Page</param>
        private void ActivatePage(IContentPage page)
        {
            Control control = page as Control;
            control.Dock = DockStyle.Fill;

            screenViewMP.Controls.Clear();

            if (screenViewMP.Controls.Contains(control))
            {
                screenViewMP.Controls.Remove(control);
                //this.Opacity = .9D;
                this.TransparencyKey = Color.Black;
            }
            else
            {
                screenViewMP.Controls.Add(control);
                //this.Opacity = 1;
                this.TransparencyKey = Color.Red;
            }
            this.Invalidate();
        }

        /// <summary>
        /// Setting btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void settingBtn_Click(object sender, EventArgs e)
        {
            ActivatePage(contentPages[1]);
        }

        /// <summary>
        /// Frame capture timer tick
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void frameCaptureTimer_Tick(object sender, EventArgs e)
        {
            //string fileName = String.Format("{1}\\{0}.bmp", index++, saveLoc);

            Point leftPt = new Point(this.Location.X, this.Location.Y);

            using (Bitmap bmp = new Bitmap(this.Bounds.Size.Width, this.Bounds.Size.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(leftPt.X, leftPt.Y, 0, 0, this.Bounds.Size, CopyPixelOperation.SourceCopy);

                    Win32Api.PCURSORINFO cinfo = new Win32Api.PCURSORINFO
                    {
                        Size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Win32Api.PCURSORINFO))
                    };

                    if (Win32Api.GetCursorInfo(out cinfo))
                    {
                        if (cinfo.Flags == Win32Api.CURSOR_SHOWING)
                        {
                            Win32Api.DrawIcon(g.GetHdc(), cinfo.ScreenPos.x, cinfo.ScreenPos.y, cinfo.Cursor);
                            g.ReleaseHdc();
                        }
                    }

                    encoder.AddFrame(bmp);
                    //bmp.Save(fileName);
                }
            }
        }

        /// <summary>
        /// Record btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void recordBtn_Click(object sender, EventArgs e)
        {
            saveLoc = Settings.Default.SaveLocation;

            screenViewMP.Controls.Clear();
            this.TransparencyKey = Color.Black;

            encoder.Start(saveLoc + "\\rec.gif");

            NotifyUser("Recoding Started");

            encoder.SetDelay(50);
            encoder.SetRepeat(0);

            frameCaptureTimer.Start();
        }

        /// <summary>
        /// Notify user
        /// </summary>
        /// <param name="message">Message</param>
        private void NotifyUser(string message)
        {
            new Task(() => NotifyUserTask(message)).Start();
        }

        /// <summary>
        /// Notify user task. Don't call this method use NotifyUser(String message);
        /// </summary>
        private void NotifyUserTask(string message)
        {
            NotificationForm notifyUser = new NotificationForm();

            Point p = new Point(this.Width / 2 - this.Width / 2, this.Height / 2 - this.Height / 2);

            //Point notifyLoc = new Point(this.Size.Width, this.Size.Height);
            notifyUser.Location = p;//new Point(this.Location.X, this.Location.Y);

            notifyUser.Popup(message, p);
        }

        /// <summary>
        /// Stop btn click
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Event arguments</param>
        private void stopBtn_Click(object sender, EventArgs e)
        {
            frameCaptureTimer.Stop();
            encoder.Finish();

            NotifyUser("Recoding Stopped");
        }

        /// <summary>
        /// Hide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideBtn_Click(object sender, EventArgs e)
        {
            //Hide ConfigMP and resize screenViewMP
            if (!configMP.Visible)
            {
                if (configMP.Tag == null)
                    configMP.Tag = configMP.Width;
                screenViewMP.Width -= (int)configMP.Tag;

                hideBtn.Image = Resources.RightSide;
                configMP.Show();  
            }
            else
            {
                hideBtn.Image = Resources.LeftSide;
                configMP.Hide();

                if (configMP.Tag == null)
                    configMP.Tag = configMP.Width;
                screenViewMP.Width += (int)configMP.Tag;
            }
        }
    } // class ScreenRecorderMP
} // namespace ScreenRecorderMP
