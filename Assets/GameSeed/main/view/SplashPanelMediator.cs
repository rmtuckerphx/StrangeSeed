using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
    [Mediates(typeof(SplashPanelView))]
    public class SplashPanelMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public SplashPanelView view { get; set; }
		
        //inject to listen for signal
        [Inject]
        public SplashStartSignal splashStartSignal { get; set; }

        //inject to dispatch
        [Inject]
        public SplashCompleteSignal splashCompleteSignal { get; set; }
	
		public override void OnRegister()
		{
            //Listen out for this Signal to fire
            splashStartSignal.AddListener(onSplashStarted);
			
			//Listen to the view for a local signal
			view.splashCompleteSignal.AddListener(onSplashComplete);
			
			view.init();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners 
            splashStartSignal.RemoveListener(onSplashStarted);
            view.splashCompleteSignal.RemoveListener(onSplashComplete);
		}

        private void onSplashComplete()
		{
            view.Hide();
            splashCompleteSignal.Dispatch();
		}

        private void onSplashStarted()
        {
            view.startAnimation();
        }
	}
}

