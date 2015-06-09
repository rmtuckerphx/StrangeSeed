//Write in all the Cross-Context bindings

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using StrangeSeed.Common;

namespace StrangeSeed.Main
{
    public class MainContext : SeedContext
	{
        public MainContext(MonoBehaviour contextView)
            : base(contextView)
        {
        }

        protected override void MapBindingsWhenFirstContext()
        {
            //The MainContext should always be the first to run. The exception to this is 
            //when testing other contexts in "stand alone" mode meaning that they are
            //running without MainContext being run.

            //cross-context bindings
            injectionBinder.Bind<GameStartSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<GameEndSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelStartSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelEndSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UpdateLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UpdateLivesSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UpdateScoreSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadSceneSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowOverlaySignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<HideOverlaySignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowLoadingScreenSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<HideLoadingScreenSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadingScreenProgressSignal>().ToSingleton().CrossContext();


            //context-specific bindings
            injectionBinder.Bind<SplashStartSignal>().ToSingleton();

            commandBinder.Bind<StartSignal>().To<MainStartupCommand>();
            commandBinder.Bind<SplashCompleteSignal>().To<SplashEndCommand>();
            commandBinder.Bind<LoadSceneSignal>().To<LoadSceneCommand>();

            mediationBinder.Bind<OverlayView>().To<OverlayMediator>();
        }
	}
}

