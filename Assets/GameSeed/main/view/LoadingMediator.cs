using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
    [Mediates(typeof(LoadingView))]
    public class LoadingMediator : Mediator
	{
        //inject to call methods
		[Inject]
        public LoadingView view { get; set; }
		
        //inject to listen for signal
        [Inject]
        public ShowLoadingScreenSignal showLoadingScreenSignal { get; set; }

        //inject to listen for signal
        [Inject]
        public HideLoadingScreenSignal hideLoadingScreenSignal { get; set; }

        //inject to listen for signal
        [Inject]
        public LoadingScreenProgressSignal loadingScreenProgressSignal { get; set; }


		public override void OnRegister()
		{
            //Listen for the following signals to fire
            showLoadingScreenSignal.AddListener(onShow);
            hideLoadingScreenSignal.AddListener(onHide);
            loadingScreenProgressSignal.AddListener(onProgress);
			
			view.init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            showLoadingScreenSignal.RemoveListener(onShow);
            hideLoadingScreenSignal.RemoveListener(onHide);
            loadingScreenProgressSignal.RemoveListener(onProgress);
        }

        private void onShow()
		{
            view.SetLoadingText("LOADING...");
            view.Show();
		}

        private void onHide()
        {
            view.Hide();
        }

        private void onProgress(float value)
        {
            string percentText = string.Format("{0:P0} Complete", value);
            view.UpdateProgress(value, percentText, null);
        }
	}
}

