using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.EventSystems;
using StrangeSeed.UI;
using StrangeSeed.Common;

namespace StrangeSeed.Game
{
    public class GameHomeView : BaseScreenView
    {
        // local signal (no binding in Context); only used by Mediator
        internal Signal localShowSlideBottomDialogSignal = new Signal();
        internal Signal localShowSlideTopDialogSignal = new Signal();
        internal Signal localShowSlideLeftDialogSignal = new Signal();
        internal Signal localShowSlideRightDialogSignal = new Signal();        
        internal Signal<string> localLoadLevelSignal = new Signal<string>();

        // attached to button On Click via Inspector
        public void ShowSlideBottomDialog()
        {
            // notify via local signal
            localShowSlideBottomDialogSignal.Dispatch();
        }

        public void ShowSlideTopDialog()
        {
            // notify via local signal
            localShowSlideTopDialogSignal.Dispatch();
        }

        public void ShowSlideLeftDialog()
        {
            // notify via local signal
            localShowSlideLeftDialogSignal.Dispatch();
        }

        public void ShowSlideRightDialog()
        {
            // notify via local signal
            localShowSlideRightDialogSignal.Dispatch();
        }

        public void LoadLevel(string levelName)
        {
            localLoadLevelSignal.Dispatch(levelName);
        }
    }
}
