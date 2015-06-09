using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.EventSystems;

namespace StrangeSeed.UI
{
    public class DebugView : View
    {
        // local signals (no binding in Context); only used by Mediator
        internal Signal localShowSlideBottomDialogSignal = new Signal();
        internal Signal localShowSlideTopDialogSignal = new Signal();
        internal Signal localShowSlideLeftDialogSignal = new Signal();
        internal Signal localShowSlideRightDialogSignal = new Signal();
        internal Signal localShowFadeCenterDialogSignal = new Signal();
        

        private Animator animator;

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

        public void ShowFadeCenterDialog()
        {
            // notify via local signal
            localShowFadeCenterDialogSignal.Dispatch();
        }

        internal void init()
        {
            Debug.Log("DebugView - init");
        }
    }
}
