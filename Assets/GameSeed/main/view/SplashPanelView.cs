using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Linq;

namespace StrangeSeed.Main
{
    public class SplashPanelView : View
    {
        internal Signal splashCompleteSignal = new Signal();

        private Animator animator;
        private Canvas canvas;

        //attached to Animation Event when splash animation ends
        public void SplashComplete()
        {
            splashCompleteSignal.Dispatch();
        }

        internal void init()
        {
            animator = this.GetComponent<Animator>();
            Debug.Log(animator.isActiveAndEnabled);

            canvas = this.GetComponentsInParent<Canvas>().FirstOrDefault();
        }

        internal void startAnimation()
        {
            if (canvas != null)
            {
                canvas.enabled = true;
            }

            animator.enabled = true;
        }

        internal void Hide()
        {
            if (canvas != null)
            {
                canvas.enabled = false;
            }
        }
    }
}
