using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinishGame : MonoBehaviour
{
    public GameObject loadingManager;
    public UIFadeAnimation buttonText;
    public Vector2 outroScale;
    public Vector2 introScale;
    public float tweenDuration;
    public float growDelay;
    public float loadDelay;

    public void FinishGame()
    {
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
        StartCoroutine(LoadEnd());
    }

    IEnumerator LoadEnd()
    {
        yield return new WaitForSeconds(loadDelay);
        loadingManager.SetActive(true);
        loadingManager.GetComponent<UILoading>().LoadEndScene();
    }
}
