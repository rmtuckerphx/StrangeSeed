using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.UI
{
    [Mediates(typeof(SlideLeftDialogView))]
    public class SlideLeftDialogMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public SlideLeftDialogView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowSlideLeftDialogSignal showSlideLeftDialogSignal { get; set; }
		
		public override void OnRegister()
		{          
            //Listen out for this Signal to fire
            showSlideLeftDialogSignal.AddListener(onShowDialog);
			
			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showSlideLeftDialogSignal.RemoveListener(onShowDialog);
		}

        private void onShowDialog()
        {
            view.Show();
        }
	}
}

