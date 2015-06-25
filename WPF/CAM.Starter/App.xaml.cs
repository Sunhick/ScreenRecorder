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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using log4net;

namespace CAM.Starter
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(App));

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
        }

        private void CurrentDomainUnhandledException(object theSender, UnhandledExceptionEventArgs theArgs)
        {
            Log.Fatal("Unhandled exception from CAM Recorder!", (Exception)theArgs.ExceptionObject);
            CreateDump();
        }

        private void CreateDump()
        {
            string aDirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var aDumpProcess = new Process();
            var aCurrentProcess = Process.GetCurrentProcess();

            var aPId = aCurrentProcess.Id.ToString(CultureInfo.InvariantCulture);

            string aDumpFilePath = Path.Combine(aDirectoryName, "CAM.Starter_" + aPId + ".dmp");

            Log.Info("Dumping process to file :" + aDumpFilePath);

            aDumpProcess.StartInfo = new ProcessStartInfo("Extern\\procdump.exe",
                string.Format("{0} {1}", aPId, aDumpFilePath));
            aDumpProcess.Start();
            aDumpProcess.WaitForExit();

            Log.Info("Killing CAM.Starter.exe....");
            aCurrentProcess.Kill();
        }

        protected override void OnStartup(StartupEventArgs theArgs)
        {
            var aBootstrapper = new Bootstrapper();
            aBootstrapper.Run();
        }
    }
}