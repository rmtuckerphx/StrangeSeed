using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.UI
{
    [Mediates(typeof(FadeCenterDialogView))]
    public class FadeCenterDialogMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public FadeCenterDialogView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowFadeCenterDialogSignal showFadeCenteralogSignal { get; set; }
			
		public override void OnRegister()
		{
            //Listen out for this Signal to fire
            showFadeCenteralogSignal.AddListener(onShowDialog);
			
			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showFadeCenteralogSignal.RemoveListener(onShowDialog);
		}

        private void onShowDialog()
        {
            view.Show();
        }
	}
}

