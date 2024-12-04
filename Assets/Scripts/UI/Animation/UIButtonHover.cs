// Created by Devan Laczko, 04/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class UIButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPos;
    [SerializeField] private bool moveX;
    [SerializeField] private bool moveY;
    [SerializeField] private Vector2 hoverPos;
    [SerializeField] private float tweenDuration;

    public void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _startPos = gameObject.GetComponent<UIFloatAnimation>().onscreenPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable)
        {
            if (moveX && !moveY)
            {
                _rectTransform.DOAnchorPosX(hoverPos.x, tweenDuration);
                
            }
            else if (!moveX && moveY)
            {
                _rectTransform.DOAnchorPosY(hoverPos.y, tweenDuration);
            }
            else if (moveX && moveY)
            {
                _rectTransform.DOAnchorPos(hoverPos, tweenDuration);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable)
        {
            if (moveX && !moveY)
            {
                _rectTransform.DOAnchorPosX(_startPos.x, tweenDuration);
            }
            else if (!moveX && moveY)
            {
                _rectTransform.DOAnchorPosY(_startPos.y, tweenDuration);
            }
            else if (moveX && moveY)
            {
                _rectTransform.DOAnchorPos(_startPos, tweenDuration);
            }
        }
    }
}
