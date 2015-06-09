using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;
using StrangeSeed.UI;

namespace StrangeSeed.UI
{
    //don't use implicit binding, when DebugView/Mediator will only be used when scene is run in a standalone context.
    public class DebugMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public DebugView view { get; set; }

        //inject to dispatch
        [Inject]
        public ShowSlideBottomDialogSignal showSlideBottomDialogSignal { get; set; }

        //inject to dispatch
        [Inject]
        public ShowSlideTopDialogSignal showSlideTopDialogSignal { get; set; }

        //inject to dispatch
        [Inject]
        public ShowSlideLeftDialogSignal showSlideLeftDialogSignal { get; set; }

        //inject to dispatch
        [Inject]
        public ShowSlideRightDialogSignal showSlideRightDialogSignal { get; set; }

        //inject to dispatch
        [Inject]
        public ShowFadeCenterDialogSignal showFadeCenterDialogSignal { get; set; }

		
		public override void OnRegister()
		{		
			//Listen to the view for local signals
            view.localShowSlideBottomDialogSignal.AddListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.AddListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.AddListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.AddListener(onShowSlideRightDialog);
            view.localShowFadeCenterDialogSignal.AddListener(onShowFadeCenterDialog);
			
			view.init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners 
            view.localShowSlideBottomDialogSignal.RemoveListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.RemoveListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.RemoveListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.RemoveListener(onShowSlideRightDialog);
            view.localShowFadeCenterDialogSignal.RemoveListener(onShowFadeCenterDialog);
		}

        private void onShowSlideBottomDialog()
		{
            showSlideBottomDialogSignal.Dispatch();
		}

        private void onShowSlideTopDialog()
        {
            showSlideTopDialogSignal.Dispatch();
        }

        private void onShowSlideLeftDialog()
        {
            showSlideLeftDialogSignal.Dispatch();
        }

        private void onShowSlideRightDialog()
        {
            showSlideRightDialogSignal.Dispatch();
        }

        private void onShowFadeCenterDialog()
        {
            showFadeCenterDialogSignal.Dispatch();
        }
	}
}

