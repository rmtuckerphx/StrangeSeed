//Every context starts by attaching a ContextView to a GameObject.
//The main job of this ContextView is to instantiate the Context.
//Remember, if the GameObject is destroyed, the Context and all your
//bindings go with it.

//This ContextView has the following jobs:
//1. Provide the Cross-Context dependencies (see MainContext)
//2. Provide dependencies needed for this context (see MainContext)
//3. Start the Splash Screen (see MainStartupCommand)

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;

namespace StrangeSeed.Main
{
	public class MainBootstrap : ContextView
	{
	
		void Awake()
		{
			//Instantiate the context, passing it this instance.
			context = new MainContext(this);
		}
	}
}

