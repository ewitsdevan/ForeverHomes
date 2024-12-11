using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    public SewingGameManager manager;
    public GameObject outcomePanel;
    public GameObject retryButton;
    public GameObject successText;
    public GameObject failText;
    public UISFX sfxManager;
    public ParticleSystem confetti;
    public UIFloatAnimation scoreSlider;

    private bool once;

    private void OnEnable()
    {
        manager.sewingGameEndEvent += gameEnd;
        
    }

    void gameEnd(bool hasWon)
    {
        if (hasWon)
        {
            Celebrate();
        }
        else if (!hasWon)
        {
            Fail();
        }
    }

    void Celebrate()
    {
        if (once == false)
        {
            once = true;
            Debug.Log("particle effect, wooo, back to main scene");
            scoreSlider.OutroAnimation();
            successText.SetActive(true);
            outcomePanel.SetActive(true);
            sfxManager.ConfettiSound();
            confetti.Play();

            if (!UIStickerManager.sewingEarned)
            {
                UIStickerManager.sewingEarned = true;
                UIStickerManager.wonMinigame = true;
            }
        }
    }

    void Fail()
    {
        if (once == false)
        {
            Debug.Log("boooo u suck");
            scoreSlider.OutroAnimation();
            failText.SetActive(true);
            retryButton.SetActive(true);
            outcomePanel.SetActive(true);
            once = true;
        }
    }

    private void OnDisable()
    {
        manager.sewingGameEndEvent -= gameEnd;
    }
}
