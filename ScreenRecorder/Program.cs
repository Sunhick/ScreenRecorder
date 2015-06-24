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
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using log4net;
using ScreenRecorder.Properties;

namespace ScreenRecorder
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (Program).Name);

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Setup();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScreenRecorderMP.ScreenRecorder());
        }

        /// <summary>
        ///     initial setup
        /// </summary>
        private static void Setup()
        {
            var root = AppDomain.CurrentDomain;
            var setup = new AppDomainSetup
            {
                ApplicationBase = root.SetupInformation.ApplicationBase
            };

            log.Info("Setting the UI language to " + Settings.Default.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
        }
    }
}