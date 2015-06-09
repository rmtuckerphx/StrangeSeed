//Show Game Over screen
using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace StrangeSeed.Main
{
	public class GameCompleteCommand : Command
	{
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		public override void Execute()
		{
            //int score = (int)evt.data;
			
            //Debug.Log ("MAIN SCENE KNOWS THAT GAME IS OVER. Your score is: " + score);
		}
	}
}

