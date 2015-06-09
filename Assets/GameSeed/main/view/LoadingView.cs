using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Linq;
using UnityEngine.UI;

namespace StrangeSeed.Main
{
    public class LoadingView : View
    {
        private CanvasGroup canvasGroup;
        private Text loadingText;
        private Text percentText;
        private Slider progressBar;

        internal void init()
        {
            canvasGroup = this.GetComponent<CanvasGroup>();
            loadingText = this.transform.Find("ProgressPanel/LoadingText").GetComponent<Text>();
            percentText = this.transform.Find("ProgressPanel/PercentText").GetComponent<Text>();
            progressBar = this.transform.Find("ProgressPanel/ProgressBar").GetComponent<Slider>();
        }

        internal void Hide()
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
            }
        }

        internal void Show()
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
            }
        }

        internal void UpdateProgress(float value, string percentText, string loadingText)
        {
            this.progressBar.value = value;

            if (loadingText != null)
            {
                this.loadingText.text = loadingText;
            }

            if (percentText != null)
            {
                this.percentText.text = percentText;
            }
        }

        internal void SetLoadingText(string text)
        {
            this.loadingText.text = text;
        }

        internal void SetPercentText(string text)
        {
            this.percentText.text = text;
        }

    }
}
