// Created by Devan Laczko, 07/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICredits : MonoBehaviour
{
    public UIFadeAnimation[] elements;
    public float fadeDuration;
    public float displayDuration;
    public UILoading loadingManager;
    public UIFloatAnimation controls;
    private int currentElement;
    private bool once;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextElement());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !once)
        {
            StartCoroutine(LastElement());
            once = true;
        }
    }

    IEnumerator ShowElement()
    {
        elements[currentElement].tweenDuration = fadeDuration;
        elements[currentElement].IntroAnimaton();

        yield return new WaitForSeconds(displayDuration);
        
        elements[currentElement].OutroAnimation();

        if (currentElement == elements.Length - 1)
        {
            StartCoroutine(LastElement());
        }
        else
        {
            currentElement++;
            StartCoroutine(NextElement());
        }
    }

    IEnumerator NextElement()
    {
        yield return new WaitForSeconds(fadeDuration);
        StartCoroutine(ShowElement());
    }

    IEnumerator LastElement()
    {
        controls.OutroAnimation();
        yield return new WaitForSeconds(fadeDuration);
        loadingManager.gameObject.SetActive(true);
        loadingManager.LoadMenuScene();
    }

    public void SkipButton()
    {
        controls.OutroAnimation();
        loadingManager.gameObject.SetActive(true);
        loadingManager.LoadMenuScene();
    }
}
