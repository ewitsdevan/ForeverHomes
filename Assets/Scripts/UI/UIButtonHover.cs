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
    public float offset;
    private Vector3 startPos;

    public void Awake()
    {
        startPos = gameObject.transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //startPos = gameObject.transform.position;

        if (gameObject.GetComponent<Button>().interactable)
        {
            gameObject.transform.position += new Vector3(offset, 0, 0);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable)
        {
            gameObject.transform.position = startPos;
        }
    }
}
