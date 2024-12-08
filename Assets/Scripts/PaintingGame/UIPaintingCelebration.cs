using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPaintingCelebration : MonoBehaviour
{
    public Painting paintingManager;
    public GameObject successText;
    public GameObject returnButton;
    public UISFX sfxManager;
    public ParticleSystem confetti;

    private bool _once;
    void OnEnable()
    {
        paintingManager.paintingGameEndEvent += GameFinished;
    }

    void OnDisable()
    {
        paintingManager.paintingGameEndEvent -= GameFinished;
    }

    public void GameFinished(bool hasFinished)
    {
        if (hasFinished && !_once)
        {
            successText.SetActive(true);
            returnButton.SetActive(true);
            sfxManager.ConfettiSound();
            confetti.Play();
            
            if (!UIStickerManager.paintingEarned)
            {
                UIStickerManager.paintingEarned = true;
                UIStickerManager.wonMinigame = true;
            }
        }
    }
}
