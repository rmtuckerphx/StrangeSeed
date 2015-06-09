//Shows the loading screen and updates the progress for all scenes passed in.
//Closes loading screen when complete.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.Collections;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
	public class LoadSceneCommand : Command
	{
        //inject to be able to call Coroutines in Command
        [Inject]
        public IRoutineRunner routineRunner { get; set; }

        //inject to dispatch
        [Inject]
        public ShowLoadingScreenSignal showLoadingScreenSignal { get; set; }

        //inject to dispatch
        [Inject]
        public HideLoadingScreenSignal hideLoadingScreenSignal { get; set; }

        //inject to dispatch
        [Inject]
        public LoadingScreenProgressSignal loadingScreenProgressSignal { get; set; }

        //inject to get list of scenes passed when signal associated with this command was dispatched.
        [Inject]
        public string[] scenes { get; set; }


        public override void Execute()
        {
            routineRunner.StartCoroutine(loadScenesAsync());
        }

        private IEnumerator loadScenesAsync()
        {
            showLoadingScreenSignal.Dispatch();

            //when multiple scenes are passed, divide the progress bar by the number of scenes.
            //for 2 scenes, each scene will move the progress bar by 50%
            for (int i = 0; i < scenes.Length; i++)
            {
                var scene = scenes[i];
                float multiplier = 1f / scenes.Length;
                float minValue = multiplier * i;

                yield return routineRunner.StartCoroutine(loadSceneAsyncWithProgressSignal(scene, minValue, multiplier));
                yield return new WaitForSeconds(0.5f);
            }

            hideLoadingScreenSignal.Dispatch();
        }

        //Note the use of LoadLevelAdditive. This means we're ADDING to the scene, rather than destroying it. 
        //Each portion of the progress bar associated with a loading scene will move based on the operation.progress value.
        private IEnumerator loadSceneAsyncWithProgressSignal(string levelName, float minValue, float multiplier)
        {
            AsyncOperation operation = Application.LoadLevelAdditiveAsync(levelName);
            while (!operation.isDone)
            {
                yield return operation.isDone;

                var progress = (operation.progress * multiplier) + minValue;
                Debug.Log(levelName + " loading progress: " + progress);
                loadingScreenProgressSignal.Dispatch(progress);
            }
            Debug.Log(levelName + " load done");
        }
	}
}

