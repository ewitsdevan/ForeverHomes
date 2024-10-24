// Created by Devan Laczko 25/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartAnimation : MonoBehaviour
{
    public bool triggerOnStart;
    public UIAutoAnimation[] animationList;
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
        StartCoroutine(AnimateEntrance(delayBetween));
    }

    public void QuickEntranceAnimation()
    {
        StartCoroutine(AnimateEntrance(0));
    }

    IEnumerator AnimateEntrance(float delay)
    {
        if (i < animationList.Length)
        {
            yield return new WaitForSeconds(delay);
            animationList[i].gameObject.SetActive(true);
            animationList[i].EntranceAnimation();
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
