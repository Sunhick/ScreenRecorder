using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using ScreenRecorder.Properties;

namespace ScreenRecorder
{
    static class Starter
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setup();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenRecorderMP.ScreenRecorder());
        }

        /// <summary>
        /// initial setup
        /// </summary>
        private static void Setup()
        {
            AppDomain root = AppDomain.CurrentDomain;
            AppDomainSetup setup = new AppDomainSetup
            { 
                ApplicationBase = root.SetupInformation.ApplicationBase 
            };

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Language);
        }
    }
}
