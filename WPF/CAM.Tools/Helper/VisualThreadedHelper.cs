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
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using log4net;

namespace CAM.Tools.Helper
{
    internal class VisualThreadedHelper : IDisposable
    {
        private readonly ILog Log = LogManager.GetLogger(typeof (VisualThreadedHelper));
        private readonly AutoResetEvent myChildVisualTargetEvent = new AutoResetEvent(false);
        private bool myDisposed = false;
        private Label myLabel;
        private DateTime myStartTime;
        private DispatcherTimer myTimer;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void StartTimer()
        {
            if (!myTimer.Dispatcher.CheckAccess())
            {
                Log.Debug(string.Format("Dispatching Start Timer from thread:{0} to visual thread:{1}",
                    Thread.CurrentThread.ManagedThreadId, myLabel.Dispatcher.Thread.ManagedThreadId));
                myLabel.Dispatcher.BeginInvoke(new Action(StartTimer), DispatcherPriority.Normal);
                return;
            }

            Log.Debug("Starting threaded timer.");
            myStartTime = DateTime.Now;
            myTimer.Start();
        }

        public void StopTimer()
        {
            if (!myTimer.Dispatcher.CheckAccess())
            {
                myLabel.Dispatcher.BeginInvoke(new Action(StopTimer), DispatcherPriority.Normal);
                return;
            }

            Log.Debug("Stopping threaded timer.");
            myTimer.Stop();
        }

        public Visual CreateThreadedLabelTimer()
        {
            // Create the HostVisual that will "contain" the VisualTarget
            // on the worker thread.
            var aHostVisual = new HostVisual();

            // Spin up a worker thread, and pass it the HostVisual that it
            // should be part of.
            var aThread = new Thread(RecordTimerWorkerThread);
            aThread.SetApartmentState(ApartmentState.STA);

            aThread.IsBackground = true;
            aThread.Start(aHostVisual);

            // Wait for the worker thread to spin up and create the VisualTarget.
            myChildVisualTargetEvent.WaitOne();

            return aHostVisual;
        }

        private FrameworkElement CreateRecordTimerLabel()
        {
            myLabel = new Label
            {
                Content = "REC #:#:#",
                Name = "RecordTimer",
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };

            myTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};
            myTimer.Tick += OnTimedEvent;

            Log.Info("Created Record timer label in thread: " + Thread.CurrentThread.ManagedThreadId);
            return myLabel;
        }

        private void OnTimedEvent(object theSender, EventArgs theArgs)
        {
            var aDuration = DateTime.Now - myStartTime;
            myLabel.Content = String.Format("REC: {0}:{1}:{2}", aDuration.Hours, aDuration.Minutes,
                aDuration.Seconds);
        }


        private void RecordTimerWorkerThread(object theArg)
        {
            // Create the VisualTargetPresentationSource and then signal the
            // calling thread, so that it can continue without waiting for us.
            var aHostVisual = (HostVisual) theArg;
            var aVisualTargetPs = new VisualTargetPresentationSource(aHostVisual);
            myChildVisualTargetEvent.Set();
            // Create a Label and use it as the root visual for the
            // VisualTarget.
            aVisualTargetPs.RootVisual = CreateRecordTimerLabel();
            // Run a dispatcher for this worker thread.  This is the central
            // processing loop for WPF.
            Log.Info("Running dispatcher for thread: " + Thread.CurrentThread.ManagedThreadId);
            Dispatcher.Run();
        }

        protected virtual void Dispose(bool theDisposing)
        {
            if (myDisposed)
            {
                Log.Fatal("VisualThreadedHelper object is already disposed.");
                return;
            }

            if (theDisposing)
            {
                if (myTimer.IsEnabled)
                {
                    Log.Debug("Force stopping the timer in dispose");
                    myTimer.Stop();
                }
                myTimer.Tick -= OnTimedEvent;
                myTimer = null;
                myLabel = null;
            }
        }
    }
}