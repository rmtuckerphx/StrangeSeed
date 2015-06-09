using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.UI
{
    [Mediates(typeof(SlideTopDialogView))]
    public class SlideTopDialogMediator : Mediator
	{
        //inject to call methods
        [Inject]
        public SlideTopDialogView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowSlideTopDialogSignal showSlideTopalogSignal { get; set; }
		
		public override void OnRegister()
		{
            //Listen out for this Signal to fire
            showSlideTopalogSignal.AddListener(onShowDialog);
			
			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showSlideTopalogSignal.RemoveListener(onShowDialog);
		}

        private void onShowDialog()
        {
            view.Show();
        }
	}
}

