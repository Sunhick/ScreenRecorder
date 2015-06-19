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
using System.IO;
using System.Windows.Forms;

namespace ScreenRecorder.ContentPages
{
    /// <summary>
    ///     Information CP
    /// </summary>
    public partial class InformationCP : UserControl, IContentPage
    {
        /// <summary>
        ///     Constructor CP
        /// </summary>
        public InformationCP()
        {
            InitializeComponent();

            //load the file contents
            aboutffmpegBox.LoadFile(
                Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "About\\FfMpeg.txt"),
                RichTextBoxStreamType.PlainText
                );
        }
    }
}