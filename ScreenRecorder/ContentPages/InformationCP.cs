using System;
using System.Windows.Forms;
using System.IO;

namespace ScreenRecorder.ContentPages
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
