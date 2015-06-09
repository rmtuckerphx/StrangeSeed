//Every context starts by attaching a ContextView to a GameObject.
//The main job of this ContextView is to instantiate the Context.
//Remember, if the GameObject is destroyed, the Context and all your
//bindings go with it.

//This ContextView holds the UI. It can be helpful to break apart your
//game into multiple scenes and multiple Contexts. In particular,
//this split allows one dev/team to work on the UI while a different dev
//or team works on the game.
using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;

namespace StrangeSeed.UI
{
	public class UIBootstrap : ContextView
	{
	
		void Awake()
		{
			//Instantiate the context, passing it this instance.
            context = new UIContext(this);
		}
	}
}

