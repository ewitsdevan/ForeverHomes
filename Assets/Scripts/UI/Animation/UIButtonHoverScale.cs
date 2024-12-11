using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    [SerializeField] public Vector2 outroScale = new Vector2(1, 1);
    [SerializeField] public Vector2 introScale = new Vector2(1.1f, 1.1f);
    [SerializeField] public float tweenDuration = 0.25f;
    
    public void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable)
        {
            _rectTransform.DOScale(introScale, tweenDuration);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable)
        {
            _rectTransform.DOScale(outroScale, tweenDuration);
        }
    }
}
