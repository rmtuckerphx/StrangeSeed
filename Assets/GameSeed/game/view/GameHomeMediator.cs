using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using StrangeSeed.Common;
using StrangeSeed.UI;

namespace StrangeSeed.Game
{
    [Mediates(typeof(GameHomeView))]    
    public class GameHomeMediator : Mediator
	{
        //inject to call methods
        [Inject]
        public GameHomeView view { get; set; }

        // application-level signal (binding in Context)
        // Inject to listen for signal
        [Inject]
        public ShowSlideBottomDialogSignal showSlideBottomDialogSignal { get; set; }

        // Inject to listen for signal
        [Inject]
        public ShowSlideTopDialogSignal showSlideTopDialogSignal { get; set; }

        // Inject to listen for signal
        [Inject]
        public ShowSlideLeftDialogSignal showSlideLeftDialogSignal { get; set; }

        // Inject to listen for signal
        [Inject]
        public ShowSlideRightDialogSignal showSlideRightDialogSignal { get; set; }

        //inject to dispatch
        [Inject]
        public LoadSceneSignal loadScreenSignal { get; set; }
	
		public override void OnRegister()
		{
			//Listen to the view for a Signal
            view.localShowSlideBottomDialogSignal.AddListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.AddListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.AddListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.AddListener(onShowSlideRightDialog);
            view.localLoadLevelSignal.AddListener(onLoadLevel);
			
			view.init ();
            view.Show();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners
            view.localShowSlideBottomDialogSignal.RemoveListener(onShowSlideBottomDialog);
            view.localShowSlideTopDialogSignal.RemoveListener(onShowSlideTopDialog);
            view.localShowSlideLeftDialogSignal.RemoveListener(onShowSlideLeftDialog);
            view.localShowSlideRightDialogSignal.RemoveListener(onShowSlideRightDialog);
            view.localLoadLevelSignal.RemoveListener(onLoadLevel);
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

        private void onLoadLevel(string levelName)
        {
            view.Hide();

            //dispatch global signal
            loadScreenSignal.Dispatch(new string[] { levelName });
        }
	}
}

