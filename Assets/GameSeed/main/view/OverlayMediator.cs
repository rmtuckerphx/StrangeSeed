using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
    public class OverlayMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public OverlayView view { get; set; }

        //inject to listen for signal
        [Inject]
        public ShowOverlaySignal showOverlaySignal { get; set; }

        //inject to listen for signal
        [Inject]
        public HideOverlaySignal hideOverlaySignal { get; set; }

		public override void OnRegister()
		{
            //Listen out for this Signal to fire
            showOverlaySignal.AddListener(onShow);
            hideOverlaySignal.AddListener(onHide);	
	
			view.init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showOverlaySignal.RemoveListener(onShow);
            hideOverlaySignal.RemoveListener(onHide);
        }

        private void onShow()
		{
            view.Show();
		}

        private void onHide()
        {
            view.Hide();
        }
	}
}

