//This file contains all the signals that are dispatched between multiple Contexts

using System;
using strange.extensions.signal.impl;

namespace StrangeSeed.Common
{
    // These signals are bound as CrossContext in MainContext
    // When contexts other than MainContext (UIContext, GameContext, etc.) are run 
    // as a "stand alone"(first) context, these signals will need to be added in that context.
    public class GameStartSignal : Signal { }
    public class GameEndSignal : Signal { }
    public class LevelStartSignal : Signal { }
    public class LevelEndSignal : Signal { }
    public class LoadSceneSignal : Signal<string[]> { }
    
    public class UpdateLivesSignal : Signal<int> { }
    public class UpdateScoreSignal : Signal<int> { }
    public class UpdateLevelSignal : Signal<int> { }
    
    public class ShowOverlaySignal : Signal { }
    public class HideOverlaySignal : Signal { }

    public class ShowLoadingScreenSignal : Signal { }
    public class HideLoadingScreenSignal : Signal { }
    public class LoadingScreenProgressSignal : Signal<float> { }
    
    
    // This context is not bound as CrossContext but is added as a Command Binder to 
    // each context: MainContext, UIContext, GameContext
    public class StartSignal : Signal{}
}


