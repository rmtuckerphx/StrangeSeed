//This context starts the splash screen

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
    public class MainStartupCommand : Command
    {
        //inject so we can dispatch
        [Inject]
        public SplashStartSignal splashStartSignal { get; set; }

        public override void Execute()
        {
            Debug.Log("MainStartupCommand Executed");
            splashStartSignal.Dispatch();
        }
    }
}

