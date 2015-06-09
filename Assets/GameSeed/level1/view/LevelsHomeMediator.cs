using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;
using StrangeSeed.UI;

namespace StrangeSeed.Level1
{
    [Mediates(typeof(LevelsHomeView))]    
    public class LevelsHomeMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public LevelsHomeView view { get; set; }

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

		public override void OnRegister()
		{	
			//Listen to the view for local signals
            view.localShowSlideBottomDialogSignal.AddListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.AddListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.AddListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.AddListener(onShowSlideRightDialog);
			
			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            view.localShowSlideBottomDialogSignal.RemoveListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.RemoveListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.RemoveListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.RemoveListener(onShowSlideRightDialog);
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
	}
}

