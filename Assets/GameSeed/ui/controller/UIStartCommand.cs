//Make sure the "debug" screen is hidden.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.Linq;

namespace StrangeSeed.UI
{
	public class UIStartCommand : Command
	{
        //inject to find debug canvas layer
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		public override void Execute()
		{
            Transform debugViewTransform = contextView.transform.Find("DebugCanvasLayer") as Transform;
            if (debugViewTransform != null)
            {
                Canvas canvas = debugViewTransform.GetComponent<Canvas>();
                canvas.enabled = false;
            }

		}
	}
}

