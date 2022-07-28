using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadingCanvasGroup;

    public bool isFadedOut = true;

    public void Fader()
    {
        if (isFadedOut)
        {
            fadingCanvasGroup.DOFade(1, 2);
        }
        else
        {
            fadingCanvasGroup.DOFade(0, 2);
        }
    }
}
