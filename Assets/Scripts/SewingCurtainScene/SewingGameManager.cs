using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SewingGameManager : MonoBehaviour
{
    public Raycast raycast;
    public NeedleControl needleControl;
    
    public bool hasFinished = false;
    public bool hasWon = false;
    public float winThreshold = 800f;
    public float sewingScore = 0f;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    public Material green;
    public TextMeshProUGUI score;
    public Slider scoreSlider;
    
    public delegate void SewingGameStartEvent();
    public event SewingGameStartEvent sewingGameStartEvent;
    
    public delegate void SewingGameEndEvent(bool hasWon);
    public event SewingGameEndEvent sewingGameEndEvent;

    [Button]
    public void BeginGame()
    {
        sewingGameStartEvent?.Invoke();
        scoreSlider.maxValue = winThreshold;
        StartCoroutine(waitToBegin());
        
    }

    IEnumerator waitToBegin()
    {
        yield return new WaitForSeconds(1);
        light1.GetComponent<Renderer>().material = green;
        yield return new WaitForSeconds(1);
        light2.GetComponent<Renderer>().material = green;
        yield return new WaitForSeconds(1);
        light3.GetComponent<Renderer>().material = green;
        needleControl.enabled = true;
        raycast.enabled = true;
    }

    private void Update()
    {
        if (hasFinished)
        {
            //game has ended
            if (sewingScore > winThreshold)
            {
                hasWon = true;
                sewingGameEndEvent?.Invoke(hasWon);
            }
            else
            {
                hasWon = false;
                sewingGameEndEvent?.Invoke(hasWon);
            }
        }

        score.text = new string(sewingScore + "/" + winThreshold);
        scoreSlider.value = sewingScore;
    }
}
