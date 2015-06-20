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
using System.Threading;
using System.Windows.Threading;
using log4net;

namespace CAM.Bootscreen
{
    public interface IBootSplasher
    {
        void ShowSplash();
        void CloseSplash();
        void ShowStatus(string theMessage);
    }

    public class BootSplasher : IBootSplasher
    {
        private readonly ILog Log = LogManager.GetLogger(typeof (BootSplasher));
        private Bootscreen myBootscreen;
        private Dispatcher myDispatcher;

        public void ShowSplash()
        {
            Process aCurrentProcess = Process.GetCurrentProcess();
            Log.Info(string.Format("ShowSplash() :: Process ID: {0} Thread ID: {1}", aCurrentProcess.Id,
                Thread.CurrentThread.ManagedThreadId));

            if (!myDispatcher.CheckAccess())
            {
                myDispatcher.BeginInvoke(new Action(ShowSplash), DispatcherPriority.Render);
                return;
            }

            myBootscreen.Show();
            Dispatcher.Run();
        }

        public void CloseSplash()
        {
            Process aCurrentProcess = Process.GetCurrentProcess();
            Log.Info(string.Format("CloseSplash() :: Process ID: {0} Thread ID: {1}", aCurrentProcess.Id,
                Thread.CurrentThread.ManagedThreadId));

            if (!myDispatcher.CheckAccess())
            {
                myDispatcher.BeginInvoke(new Action(CloseSplash), DispatcherPriority.Render);
                return;
            }

            myBootscreen.Close();
        }

        public void ShowStatus(string theMessage)
        {
            if (!myDispatcher.CheckAccess())
            {
                myDispatcher.BeginInvoke(new Func<string>(() =>
                {
                    ShowStatus(theMessage);
                    return null;
                }), DispatcherPriority.Normal);
                return;
            }

            var aBootscreenViewModel = (myBootscreen.DataContext) as BootscreenViewModel;
            if (aBootscreenViewModel != null)
                aBootscreenViewModel.ShowStatus(theMessage);
        }

        public void Init()
        {
            Process aCurrentProcess = Process.GetCurrentProcess();
            Log.Info(string.Format("Init Process ID: {0} Thread ID: {1}", aCurrentProcess.Id,
                Thread.CurrentThread.ManagedThreadId));
            myBootscreen = new Bootscreen(new BootscreenViewModel());
            myDispatcher = myBootscreen.Dispatcher;
        }
    }
}