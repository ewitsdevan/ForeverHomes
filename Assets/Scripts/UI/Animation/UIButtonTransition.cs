using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIButtonTransition : MonoBehaviour
{
    public GameObject loadingManager;
    public UIFadeAnimation buttonText;
    public GameObject warningPanel;
    public Vector2 moveTo;
    public Vector2 outroScale;
    public Vector2 introScale;
    public float tweenDuration;
    public float growDelay;
    public float loadDelay;

    public bool open;
    public bool finish;
    public bool credits;
    
    private RectTransform _rectTransform;

    public void Trigger()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.DOAnchorPos(moveTo, tweenDuration);
        StartCoroutine(Shrink());
    }

    IEnumerator Shrink()
    {
        yield return new WaitForSeconds(growDelay);
        buttonText.OutroAnimation();
        GetComponent<UIScaleAnimation>().tweenDuration = tweenDuration;
        GetComponent<UIScaleAnimation>().outroScale = outroScale;
        GetComponent<UIScaleAnimation>().OutroAnimation();
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(growDelay);
        GetComponent<UIScaleAnimation>().introScale = introScale;
        GetComponent<UIScaleAnimation>().IntroAnimation();

        StartCoroutine(Load());
    }
    
    IEnumerator Load()
    {
        yield return new WaitForSeconds(loadDelay);
        
        if (open)
        {
            warningPanel.SetActive(true);
            loadingManager.SetActive(true);
        }
        else
        {
            loadingManager.SetActive(true);
        }
        
        if (open)
        {
            loadingManager.GetComponent<UILoading>().LoadOpenScene();
        }
        else if (finish)
        {
            loadingManager.GetComponent<UILoading>().LoadEndScene();
        }
        else if (credits)
        {
            loadingManager.GetComponent<UILoading>().LoadCreditsScene();
        }
    }
}
