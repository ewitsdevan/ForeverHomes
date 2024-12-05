// Created by Devan Laczko, 04/12/2024

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIFloatAnimation : MonoBehaviour
{
    private RectTransform _rectTransform;
    [SerializeField] private bool onStart;
    [SerializeField] private float startDelay;
    [SerializeField] private bool moveX;
    [SerializeField] private bool moveY;
    [SerializeField] private Vector2 offscreenPos;
    [SerializeField] public Vector2 onscreenPos;
    [SerializeField] private float tweenDuration;

    [SerializeField] private bool autoHide;
    [SerializeField] private float waitDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (onStart)
        {
            _rectTransform.anchoredPosition = offscreenPos;
            StartCoroutine(StartDelay(startDelay));
        }
    }

    IEnumerator StartDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IntroAnimation();
    }

    public void IntroAnimation()
    {
        _rectTransform = GetComponent<RectTransform>();
        
        if (moveX && !moveY)
        {
            _rectTransform.DOAnchorPosX(onscreenPos.x, tweenDuration);
        }
        else if (!moveX && moveY)
        {
            _rectTransform.DOAnchorPosY(onscreenPos.y, tweenDuration);
        }
        else if (moveX && moveY)
        {
            _rectTransform.DOAnchorPos(onscreenPos, tweenDuration);
        }
        
        
        if (autoHide)
            StartCoroutine(WaitBeforeOutro());
    }

    public void OutroAnimation()
    {
        _rectTransform = GetComponent<RectTransform>();
        
        if (moveX && !moveY)
        {
            _rectTransform.DOAnchorPosX(offscreenPos.x, tweenDuration);
        }
        else if (!moveX && moveY)
        {
            _rectTransform.DOAnchorPosY(offscreenPos.y, tweenDuration);
        }
        else if (moveX && moveY)
        {
            _rectTransform.DOAnchorPos(offscreenPos, tweenDuration);
        }
    }

    IEnumerator WaitBeforeOutro()
    {
        yield return new WaitForSeconds(waitDuration);
        OutroAnimation();
    }

    public void IntroWithDelay(float parsedDelay)
    {
        _rectTransform = GetComponent<RectTransform>();
        if (moveX && !moveY)
        {
            _rectTransform.anchoredPosition = new Vector2(offscreenPos.x, _rectTransform.anchoredPosition.y);
        }
        else if (!moveX && moveY)
        {
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, offscreenPos.y);
        }
        else if (moveX && moveY)
        {
            _rectTransform.anchoredPosition = offscreenPos;
        }
        
        StartCoroutine(StartDelay(parsedDelay));
    }
}
