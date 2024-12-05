using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    public SewingGameManager manager;
    public GameObject outcomePanel;
    public GameObject successText;
    public GameObject failText;

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
            Debug.Log("particle effect, wooo, back to main scene");
            successText.SetActive(true);
            outcomePanel.SetActive(true);
            UIStickerManager.sewingEarned = true;
            UIStickerManager.wonMinigame = true;
            UIStickerManager.stickersEarned++;
            once = true;
        }
    }

    void Fail()
    {
        if (once == false)
        {
            Debug.Log("boooo u suck");
            failText.SetActive(true);
            outcomePanel.SetActive(true);
            once = true;
        }
    }

    private void OnDisable()
    {
        manager.sewingGameEndEvent -= gameEnd;
    }
}
