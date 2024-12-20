// Created by Devan Laczko, 04/12/2024

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIScaleAnimation : MonoBehaviour
{
    private RectTransform _rectTransform;
    [SerializeField] private bool onStart;
    [SerializeField] private float startDelay;
    [SerializeField] public Vector2 outroScale;
    [SerializeField] public Vector2 introScale;
    [SerializeField] public float tweenDuration;
    
    [SerializeField] private bool autoHide;
    [SerializeField] private float waitDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (onStart)
        {
            _rectTransform.localScale = outroScale;
        }
        
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        
        if (onStart)
        {
            IntroAnimation();
        }
    }

    public void IntroAnimation()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.DOScale(introScale, tweenDuration);
        
        if (autoHide)
            StartCoroutine(WaitBeforeOutro(waitDuration));
    }

    public void OutroAnimation()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.DOScale(outroScale, tweenDuration);
    }
    
    IEnumerator WaitBeforeOutro(float delay)
    {
        yield return new WaitForSeconds(delay);
        OutroAnimation();
    }

    public void OutroWithDelay(float parsedDelay)
    {
        StartCoroutine(WaitBeforeOutro(parsedDelay));
    }
}
