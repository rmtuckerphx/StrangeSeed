//The Context for our core game.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using StrangeSeed.Common;
using UnityEngine.EventSystems;
using StrangeSeed.UI;

namespace StrangeSeed.Game
{
	public class GameContext : SeedContext
	{
        public GameContext(MonoBehaviour contextView)
            : base(contextView)
		{
		}

        protected override void MapBindingsWhenFirstContext()
        {
            //Since this is a multi-context project, this method will only be executed if this context is the first to run.
            //Normally the MainContext is the first to run so this means that we are running this context in a "stand alone" mode.
            //Or in other words, the scene that loads this context is running without first running the Main scene.
            //Any bindings for Cross Context normally defined in MainContext need to be bound here so the classes in this context
            //have the required dependencies. 

            //signals
            injectionBinder.Bind<ShowSlideBottomDialogSignal>().ToSingleton();
            injectionBinder.Bind<ShowSlideTopDialogSignal>().ToSingleton();
            injectionBinder.Bind<ShowSlideLeftDialogSignal>().ToSingleton();
            injectionBinder.Bind<ShowSlideRightDialogSignal>().ToSingleton();

            //These signals are provided by MainContext when we're in a multi-context situation
            //injectionBinder.Bind<GameInputSignal>().ToSingleton();
            injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
            injectionBinder.Bind<UpdateLivesSignal>().ToSingleton();
            injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();

            //commands
            commandBinder.Bind<StartSignal>().To<GameStartCommand>().Once();

            AddEventSystem();
        }

        protected override void MapBindingsWhenNonFirstContext()
        {
            //These bindings are defined in the normal case where MainContext is executed first.

            //commands
            commandBinder.Bind<StartSignal>().To<GameStartCommand>().Once();

            DisableStandanloneGameObjects();
        }
	}
}

