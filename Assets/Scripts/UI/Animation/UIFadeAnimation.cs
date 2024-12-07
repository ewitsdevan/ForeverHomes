// Created by Devan Laczko, 19/10/2024
// Updated 04/12/2024

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFadeAnimation : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] public bool fadeInOnStart;
    [SerializeField] public bool fadeOutOnStart;
    [SerializeField] public float startDelay;
    [SerializeField] public float tweenDuration;
    
    [SerializeField] private bool autoHide;
    [SerializeField] private float waitDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        
        if (fadeInOnStart)
        {
            _canvasGroup.alpha = 0f;
        }

        if (fadeOutOnStart)
        {
            _canvasGroup.alpha = 1f;
        }
        
        StartCoroutine(StartDelay());
    }

    public void IntroAnimaton()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.DOFade(1, tweenDuration);
        
        if (autoHide)
        {
            StartCoroutine(WaitBeforeOutro());
        }
    }

    public void OutroAnimation()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.DOFade(0, tweenDuration);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        
        if (fadeInOnStart)
        {
            IntroAnimaton();
        }

        if (fadeOutOnStart)
        {
            OutroAnimation();
        }
    }
    
    IEnumerator WaitBeforeOutro()
    {
        yield return new WaitForSeconds(waitDuration);
        OutroAnimation();
    }
}
