StrangeSeed is a starter or seed project with the key points:
* StrangeIoC is used with the Model-View-Controller-Service design pattern
* The project consists of multiple contexts: MainContext, UIContext and GameContext
* When main.unity scene is executed, then MainContext is executed as the first context and the other contexts are loaded as needed. This is the normal execution flow.
* When another scene such as ui.unity is run, then MainContext is not executed and the context is said to be running in "stand alone" mode. The scene might provide a debug
view to test context functionality
* Each scene has as its root GameObject a context
* Signals (instead of Events) are bound to Commands  
* uGui is used for all UI including Splash screen, semi-transparent overlay, dialogs, loading screen, game home, etc.
* uGui screens and dialogs are defined in the various scenes as children to a Canvas object. The Canvas defines the SortOrder to get proper z-ordering. The screens are defined as Panels that 
have the following components: Canvas Group (for alpha and raycasts), Animator (for animation), and a View-derived class.
* MainContext defines the single EventSystem. When other contexts are run in "stand alone" mode, then an EventSystem will be added so they can run.
* The EventSystem can be used to call methods on a View. For example, a button click or an animation event can call view.method(); 
* Views only communicate with Mediators and use "local" signals. Mediators communicate with views using methods on the View. 
* Mediators can dispatch global signals or inject and use other dependencies such as Services.
* StrangeSeed defines base classes for screens (BaseScreenView) and dialogs (BaseDialogView). Both have Show and Hide methods and require an AnimationController 
that has an Open and Close state and an IsOpen parameter. A screen takes up the entire Screen Space whereas a dialog can be smaller. A dialog shows an overlay under the dialog.
* The project defines various animations and animation controllers for fading and sliding a screen or dialog.
* All scenes are loaded via LoadLevelAdditiveAsync by dispatching the LoadSceneSignal signal and passing it a string array of scene names to load. The Loading screen will show and the progress
bar will advance based on the number of scenes to loading and the progress.