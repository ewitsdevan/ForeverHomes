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
    [SerializeField] private Vector2 outroScale;
    [SerializeField] private Vector2 introScale;
    [SerializeField] private float tweenDuration;
    
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
    }

    public void OutroAnimation()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.DOScale(outroScale, tweenDuration);
    }
}
