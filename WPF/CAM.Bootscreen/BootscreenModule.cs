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
using System.Threading.Tasks;
using log4net;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace CAM.Bootscreen
{
    public class BootscreenModule : IModule
    {
        private readonly ILog Log = LogManager.GetLogger(typeof (BootscreenModule));
        private readonly IUnityContainer myContainer;
        private readonly BootSplasher mySplasher = new BootSplasher();

        public BootscreenModule(IUnityContainer theContainer)
        {
            myContainer = theContainer;
        }

        public void Initialize()
        {
            Log.Info("Initialzing the Bootscreen Module");
            Process aCurrentProcess = Process.GetCurrentProcess();
            Log.Info(string.Format("Process ID: {0} Thread ID: {1}", aCurrentProcess.Id,
                Thread.CurrentThread.ManagedThreadId));

            StartSTATask(Splasher);
            myContainer.RegisterInstance<IBootSplasher>("Bootscreen", mySplasher,
                new ContainerControlledLifetimeManager());
        }

        private object Splasher()
        {
            mySplasher.Init();
            mySplasher.ShowSplash();
            return null;
        }

        // ReSharper disable once InconsistentNaming
        public static Task<T> StartSTATask<T>(Func<T> theFunc)
        {
            var aTcs = new TaskCompletionSource<T>();
            var aThread = new Thread(() =>
            {
                try
                {
                    aTcs.SetResult(theFunc());
                }
                catch (Exception aE)
                {
                    aTcs.SetException(aE);
                    throw;
                }
            });
            aThread.SetApartmentState(ApartmentState.STA);
            aThread.Start();
            return aTcs.Task;
        }
    }
}