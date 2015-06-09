//Base Class for all our Contexts
//1. Provide the important bindings for a Signals-based app 
//2. Dispatch StartSignal

using System;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace StrangeSeed.Common
{
	public abstract class SignalContext : MVCSContext
	{
		public SignalContext (MonoBehaviour contextView) : base(contextView)
		{
		}

		protected override void addCoreComponents ()
		{
			base.addCoreComponents ();
			injectionBinder.Unbind<ICommandBinder> ();
			injectionBinder.Bind<ICommandBinder> ().To<SignalCommandBinder> ().ToSingleton ();
		}

		public override void Launch ()
		{
			base.Launch ();
			StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>(); 
			startSignal.Dispatch();
		}
	}
}

