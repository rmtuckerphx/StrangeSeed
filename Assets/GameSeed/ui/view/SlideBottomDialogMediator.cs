using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.UI
{
    [Mediates(typeof(SlideBottomDialogView))]
    public class SlideBottomDialogMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public SlideBottomDialogView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowSlideBottomDialogSignal showSlideBottomDialogSignal { get; set; }
			
		public override void OnRegister()
		{           
            //Listen out for this Signal to fire
            showSlideBottomDialogSignal.AddListener(onShowDialog);

			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showSlideBottomDialogSignal.RemoveListener(onShowDialog);
		}

        private void onShowDialog()
        {
            view.Show();
        }
	}
}

