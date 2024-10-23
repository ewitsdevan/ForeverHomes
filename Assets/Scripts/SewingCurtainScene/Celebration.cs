using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    public SewingGameManager manager;

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
    }

    void Celebrate()
    {
        
        Debug.Log("particle effect, wooo, back to main scene");
    }

    private void OnDisable()
    {
        manager.sewingGameEndEvent -= gameEnd;
    }
}
