//Loads additional scenes

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.Collections;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
	public class SplashEndCommand : Command
	{		
        //inject to dispatch
        [Inject]
        public LoadSceneSignal loadSceneSignal { get; set; }

        public override void Execute()
        {
            //set with string array of scenes to load; make sure they are set in File > Build Settings > Scenes In Build
            loadSceneSignal.Dispatch(new string[] { "ui", "game" });
        }
	}
}

