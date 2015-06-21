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
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace CAM.Tools.ViewModel
{
    public class ToolsViewModel : ViewModelBase
    {
        private readonly bool myCanExitApp;

        private readonly IEventAggregator myEventAggregator;
        private ToolsModel myModel;
        private IRegionManager myRegionManager;

        public ToolsViewModel(ToolsModel theModel, IEventAggregator theEventAggregator, IRegionManager theManager)
        {
            AppExitCommand = new RelayCommand(CanExitApp, AppExitEvent);
            SettingsCommand = new RelayCommand(CanOpenSettings, OpenSettings);
            StopCommand = new RelayCommand(CanStopRecording, StopRecording);
            myCanExitApp = true;
            myEventAggregator = theEventAggregator;
            myRegionManager = theManager;
            myModel = theModel;
        }

        private void StopRecording(object theObj)
        {
            myModel.EncodeBitmapsToVideo("MP4");
        }

        public ICommand AppExitCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand StopCommand { get; set; }

        private void OpenSettings(object theObj)
        {
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