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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenRecorder
{
    /// <summary>
    ///     yes no
    /// </summary>
    public enum YesNo
    {
        Yes,
        No
    };

    /// <summary>
    ///     user message box
    /// </summary>
    public partial class MessageBox : Form
    {
        /// <summary>
        ///     Yes no status
        /// </summary>
        private static YesNo yesno;

        /// <summary>
        ///     userBox Singleton
        /// </summary>
        private static MessageBox userBox;

        /// <summary>
        ///     Ctor
        /// </summary>
        private MessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     On paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(DisplayRectangle.Location,
                new Size(DisplayRectangle.Size.Width - 1, DisplayRectangle.Size.Height - 1)));
            base.OnPaint(e);
        }

        /// <summary>
        ///     on yes click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartBtn_Click(object sender, EventArgs e)
        {
            yesno = YesNo.Yes;

            Close();
        }

        /// <summary>
        ///     On No click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            yesno = YesNo.No;

            Close();
        }

        /// <summary>
        ///     Show user box
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