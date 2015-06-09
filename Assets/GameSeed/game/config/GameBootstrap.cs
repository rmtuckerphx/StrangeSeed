//Every context starts by attaching a ContextView to a GameObject.
//The main job of this ContextView is to instantiate the Context.
//Remember, if the GameObject is destroyed, the Context and all your
//bindings go with it.

//This ContextView holds the core game. It is capable of running standalone
//(run from game.unity), or as part of the integrated whole (run from main.unity).

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;

namespace StrangeSeed.Game
{
    public class GameBootstrap : ContextView
	{
	
		void Awake()
		{
			//Instantiate the context, passing it this instance.
            context = new GameContext(this);
		}
	}
}

