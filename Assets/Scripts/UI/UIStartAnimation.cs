// Created by Devan Laczko 25/10/2024
// Updated 07/11/2024

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartAnimation : MonoBehaviour
{
    public bool triggerOnStart;
    public UIAutoAnimation[] animationList;
    public float delayStart;
    public float delayBetween;

    private int i;
    
    // Start is called before the first frame update
    void Start()
    {
        if (triggerOnStart)
        {
            EntranceAnimation();
        }
    }

    public void EntranceAnimation()
    {
        StartCoroutine(DelayStart(delayStart));
    }

    public void QuickEntranceAnimation()
    {
        StartCoroutine(AnimateEntrance(0));
    }

    IEnumerator DelayStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(AnimateEntrance(delayBetween));
    }

    IEnumerator AnimateEntrance(float delay)
    {
        if (i < animationList.Length)
        {
            animationList[i].gameObject.SetActive(true);
            animationList[i].EntranceAnimation();
            yield return new WaitForSeconds(delay);
            i++;
            StartCoroutine(AnimateEntrance(delay));
        }
        else
        {
            i = 0;
            yield return null;
        }
    }

    public void ExitAnimation()
    {
        if (i < animationList.Length)
        {
            animationList[i].gameObject.SetActive(true);
            animationList[i].ExitAnimation();
            i++;
            ExitAnimation();
        }
        else
        {
            i = 0;
        }
    }
}
