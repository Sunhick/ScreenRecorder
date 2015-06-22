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

using System.Windows.Input;
using CAM.Common;
using CAM.Tools.Model;
using CAM.Tools.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace CAM.Tools.ViewModel
{
    public class ToolsViewModel : ViewModelBase
    {
        private readonly bool myCanExitApp;

        private readonly IEventAggregator myEventAggregator;
        private readonly ToolsModel myModel;
        private Cursor myCursor;
        private IRegionManager myRegionManager;
        private readonly IUnityContainer myContainer;
        private SettingsView mySettingsView;

        public ToolsViewModel(ToolsModel theModel, IEventAggregator theEventAggregator, IRegionManager theManager,
            IUnityContainer theContainer)
        {
            Cursor = Cursors.Arrow;
            myCanExitApp = true;
            myEventAggregator = theEventAggregator;
            myRegionManager = theManager;
            myContainer = theContainer;
            myModel = theModel;

            AppExitCommand = new RelayCommand(CanExitApp, AppExitEvent);
            SettingsCommand = new RelayCommand(CanOpenSettings, OpenSettings);
            StopRecordCommand = new RelayCommand(CanStopRecording, StopRecording);
            StartRecordCommand = new RelayCommand(CanStartRecording, StartRecording);
            mySettingsView = myContainer.Resolve<SettingsView>();
        }

        public ICommand AppExitCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand StopRecordCommand { get; set; }
        public ICommand StartRecordCommand { get; set; }

        public Cursor Cursor
        {
            get { return myCursor; }
            set
            {
                myCursor = value;
                OnPropertyChanged("Cursor");
            }
        }

        private bool CanStartRecording(object theObj)
        {
            return true;
        }

        private void StartRecording(object theObj)
        {
            myModel.StartRecording();
        }

        private void StopRecording(object theObj)
        {
            Cursor = Cursors.Wait;
            myModel.StopRecording();
            Cursor = Cursors.Arrow;
        }

        private void OpenSettings(object theObj)
        {
            IRegion aRegion = myRegionManager.Regions["SettingsRegion"];
            if (aRegion.Views.Contains(mySettingsView))
            {
                aRegion.Deactivate(mySettingsView);
                aRegion.Remove(mySettingsView);
                return;
            }
            aRegion.Add(mySettingsView);
            aRegion.Activate(mySettingsView);
        }

        private bool CanOpenSettings(object theObj)
        {
            return true;
        }

        private void AppExitEvent(object theObj)
        {
            myEventAggregator.GetEvent<AppExitEvent>().Publish(AppExitType.Normal);
        }

        private bool CanExitApp(object theObj)
        {
            return myCanExitApp;
        }

        private bool CanStopRecording(object theObj)
        {
            return true;
        }
    }
}