//Base Class for all our Contexts in StrangeSeed project
//1. Sets namespace(s) for mapBindings
//2. Scan for Implicit Bindings
//3. Defines helper functions

using System;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using UnityEngine.EventSystems;

namespace StrangeSeed.Common
{
    public abstract class SeedContext : SignalContext
	{
        public SeedContext(MonoBehaviour contextView)
            : base(contextView)
		{
		}

        protected override void mapBindings()
        {
            base.mapBindings();

            //map implicit bindings
            string[] usingNamespaces = GetNamespacesForMapBindings();
            if (usingNamespaces != null && usingNamespaces.Length > 0)
            {
                implicitBinder.ScanForAnnotatedClasses(usingNamespaces);
            }

            //map explicit bindings
            if (IsFirstContext)
            {
                MapBindingsWhenFirstContext();
            }
            else
            {
                MapBindingsWhenNonFirstContext();
            }

            MapAdditionalBindings();
        }

        //The MainContext should always be the first context when the Main scene is run first.
        //If a different context is the first context then that means that context is being run in 
        //"stand alone" mode.
        protected virtual void MapBindingsWhenFirstContext()
        {
        }

        //This method is used by contexts other than MainContext when run in the normal case
        //where MainContext is executed first.
        protected virtual void MapBindingsWhenNonFirstContext()
        {
        }

        //This method is alway executed regardless if the context is the first to run or not.
        //Here you can map additional bindings.
        protected virtual void MapAdditionalBindings()
        {
        }

        protected virtual string[] GetNamespacesForMapBindings()
        {
            return new string[]{"StrangeSeed"};
        }

        protected bool IsFirstContext
        {
            get
            {
                return Context.firstContext == this;
            }
        }

        protected virtual void DisableStandanloneGameObjects()
        {
            if (!IsFirstContext)
            {
                //Disable the AudioListener
                AudioListener listener = (contextView as GameObject).GetComponentInChildren<AudioListener>();
                if (listener != null)
                {
                    listener.enabled = false;
                }

                //Disable the lights
                Light[] lights = (contextView as GameObject).GetComponentsInChildren<Light>();
                foreach (Light light in lights)
                {
                    light.enabled = false;
                }
            }
        }

        protected virtual void AddEventSystem()
        {
            (contextView as GameObject).AddComponent<EventSystem>();
            (contextView as GameObject).AddComponent<StandaloneInputModule>();
            (contextView as GameObject).AddComponent<TouchInputModule>();
        }
	}
}

