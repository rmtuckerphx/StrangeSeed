//The Context for our UI.

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

namespace StrangeSeed.UI
{
    public class UIContext : SeedContext
    {
        public UIContext(MonoBehaviour contextView)
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

            //map signals normally mapped in MainContext
            injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
            injectionBinder.Bind<UpdateLivesSignal>().ToSingleton();
            injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
            injectionBinder.Bind<ShowOverlaySignal>().ToSingleton();
            injectionBinder.Bind<HideOverlaySignal>().ToSingleton();

            //commands
            commandBinder.Bind<StartSignal>().To<UIDebugStartCommand>().Once();

            //views/mediators
            mediationBinder.Bind<DebugView>().To<DebugMediator>();

            AddEventSystem();
        }

        protected override void MapBindingsWhenNonFirstContext()
        {
            //These bindings are defined in the normal case where MainContext is executed first.

            //commands
            commandBinder.Bind<StartSignal>().To<UIStartCommand>().Once();
        }

        protected override void MapAdditionalBindings()
        {
            //Map additional bindings that are always added regardless if this context was loaded first or not.

            //signals
            injectionBinder.Bind<ShowSlideBottomDialogSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowSlideTopDialogSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowSlideLeftDialogSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowSlideRightDialogSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowFadeCenterDialogSignal>().ToSingleton().CrossContext();
        }
    }
}

