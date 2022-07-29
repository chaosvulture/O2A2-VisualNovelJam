using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadingCanvasGroup;

    public bool isFadedOut = true;
    public float objectAlpha = 1f;
    public float fadeTime = 2f;

    public void Fader()
    {
        if (isFadedOut)
        {
            fadingCanvasGroup.DOFade(objectAlpha, fadeTime);
        }
        else
        {
            fadingCanvasGroup.DOFade(-objectAlpha, fadeTime);
        }
    }
}
