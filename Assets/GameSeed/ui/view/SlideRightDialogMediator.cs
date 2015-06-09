using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.UI
{
    [Mediates(typeof(SlideRightDialogView))]
    public class SlideRightDialogMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public SlideRightDialogView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowSlideRightDialogSignal showSlideRightDialogSignal { get; set; }
		
		public override void OnRegister()
		{
            //Listen out for this Signal to fire
            showSlideRightDialogSignal.AddListener(onShowDialog);
			
            view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showSlideRightDialogSignal.RemoveListener(onShowDialog);
		}

        private void onShowDialog()
        {
            view.Show();
        }
	}
}

