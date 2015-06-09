//While this Context doesn't actually need a startup Command
//I almost always leave one here...just in case.
//In any sufficiently complex project, there's pretty much
//always **something** that needs to happen on startup.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace StrangeSeed.Game
{
    public class GameStartCommand : Command
	{		
		public override void Execute()
		{
            Debug.Log("GameStartCommand - Execute");
		}
	}
}

