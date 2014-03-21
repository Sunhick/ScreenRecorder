using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenRecorder
{
    /// <summary>
    /// yes no
    /// </summary>
    public enum YesNo
    { 
        Yes,
        No
    };

    /// <summary>
    /// user message box
    /// </summary>
    public partial class MessageBox : Form
    {
        /// <summary>
        /// Yes no status
        /// </summary>
        private static YesNo yesno;

        /// <summary>
        /// userBox Singleton
        /// </summary>
        private static MessageBox userBox;

        /// <summary>
        /// Ctor
        /// </summary>
        private MessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(this.DisplayRectangle.Location,
                new Size(this.DisplayRectangle.Size.Width - 1, this.DisplayRectangle.Size.Height - 1)));
            base.OnPaint(e);
        }

        /// <summary>
        /// on yes click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartBtn_Click(object sender, EventArgs e)
        {
            yesno = YesNo.Yes;

            this.Close();
        }

        /// <summary>
        /// On No click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            yesno = YesNo.No;

            this.Close();
        }

        /// <summary>
        /// Show user box
        /// </summary>
        /// <param name="message"></param>
        /// <param name="yes"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        public static YesNo Show(string message, string yes, string no)
        {
            if (userBox == null) userBox = new MessageBox();

            userBox.userTextBox.Text = message;
            userBox.yesBtn.Text = yes;
            userBox.noBtn.Text = no;

            userBox.ShowDialog();

            return yesno;
        }
    }
}
