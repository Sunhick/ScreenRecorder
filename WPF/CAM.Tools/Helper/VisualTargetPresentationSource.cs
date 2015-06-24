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
using System.Windows;
using System.Windows.Media;

namespace CAM.Tools.Helper
{
    public class VisualTargetPresentationSource : PresentationSource
    {
        private readonly VisualTarget myVisualTarget;

        public VisualTargetPresentationSource(HostVisual theHostVisual)
        {
            myVisualTarget = new VisualTarget(theHostVisual);
        }

        public override Visual RootVisual
        {
            get { return myVisualTarget.RootVisual; }

            set
            {
                var aOldRoot = myVisualTarget.RootVisual;

                // Set the root visual of the VisualTarget.  This visual will
                // now be used to visually compose the scene.
                myVisualTarget.RootVisual = value;

                // Tell the PresentationSource that the root visual has
                // changed.  This kicks off a bunch of stuff like the
                // Loaded event.
                RootChanged(aOldRoot, value);

                // Kickoff layout...
                var aRootElement = value as UIElement;
                if (aRootElement != null)
                {
                    aRootElement.Measure(new Size(Double.PositiveInfinity,
                        Double.PositiveInfinity));
                    aRootElement.Arrange(new Rect(aRootElement.DesiredSize));
                }
            }
        }

        public override bool IsDisposed
        {
            get
            {
                // We don't support disposing this object.
                return false;
            }
        }

        protected override CompositionTarget GetCompositionTargetCore()
        {
            return myVisualTarget;
        }
    }
}