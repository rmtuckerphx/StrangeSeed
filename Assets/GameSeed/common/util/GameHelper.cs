using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.Collections;
using StrangeSeed.Common;
using strange.extensions.injector.api;
using StrangeSeed.Main;

namespace StrangeSeed.Common
{
   // [Implements(typeof(IGameHelper), InjectionBindingScope.CROSS_CONTEXT)]
    public class GameHelper : IGameHelper
    {
        //[Inject]
        //public LoadingScreenProgressSignal loadingScreenProgressSignal { get; set; }

        //public IEnumerator LoadLevelAsyncWithProgressSignal(string levelName, float minValue, float multiplier)
        //{
        //    AsyncOperation operation = Application.LoadLevelAdditiveAsync(levelName);
        //    while (!operation.isDone)
        //    {
        //        yield return operation.isDone;

        //        var progress = (operation.progress * multiplier) + minValue;
        //        Debug.Log(levelName + " loading progress: " + progress);
        //        loadingScreenProgressSignal.Dispatch(progress);
        //    }
        //    Debug.Log(levelName + " load done");
        //}

        //public IEnumerator LoadLevelAsyncWithProgressSignal(string levelName)
        //{
        //    return LoadLevelAsyncWithProgressSignal(levelName, 0f, 1f);
        //}
    }
}
