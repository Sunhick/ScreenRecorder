using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenRecorder.ContentPages;
using System.IO;

namespace ScreenRecorderMP
{
    /// <summary>
    /// Information CP 
    /// </summary>
    public partial class InformationCP : UserControl, IContentPage
    {
        /// <summary>
        /// Constructor CP
        /// </summary>
        public InformationCP()
        {
            InitializeComponent();

            //load the file contents
            aboutffmpegBox.LoadFile(
                Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "About\\FfMpeg.txt"), RichTextBoxStreamType.PlainText
                );
        }
    }
}
