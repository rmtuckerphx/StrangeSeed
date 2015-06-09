using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace StrangeSeed.Common
{
    [RequireComponent(typeof(CanvasGroup), typeof(Animator))]
    public abstract class BaseScreenView : View
    {
        private Animator animator;
        private CanvasGroup canvasGroup;

        public virtual void init()
        {
            animator = this.GetComponent<Animator>();            
            canvasGroup = this.GetComponent<CanvasGroup>();
        }

        public bool IsOpen
        {
            get { return animator.GetBool("IsOpen"); }
        }

        public void Show()
        {
            if (animator != null)
            {
                animator.SetBool("IsOpen", true);
            }
        }

        public void Hide()
        {
            if (animator != null)
            {
                animator.SetBool("IsOpen", false);
            }
        }

        public void Update()
        {
            if (animator == null) { return; }

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
            {
                canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
            }
            else
            {
                canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
            }
        }

        
    }
}
