// Created by Devan Laczko, 20/11/2024
// Updated 05/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStickerManager : MonoBehaviour
{
    public static bool wonMinigame;
    public GameObject stickerEarnedPopup;

    public static bool repairFurnitureEarned;
    public GameObject repairFurnitureSticker;

    public static bool sewingEarned;
    public GameObject sewingSticker;

    public static bool gramaphoneEarned;
    public GameObject gramaphoneSticker;

    public static bool paintingEarned;
    public GameObject paintingSticker;

    public static bool completionEarned;
    public GameObject completionSticker;

    public static int stickersEarned;
    public TextMeshProUGUI menuText;
    public Slider menuSlider;
    
    public CleaningManager cleaningManager;
    public FurnitureRepair furnitureRepair;

    public UIScaleAnimation finishGameButton;
    
    public void OnEnable()
    {
        cleaningManager.cleaningGameEndEvent += WonCleaning;
    }
    
    void Start()
    {
        if (wonMinigame)
        {
            StickerEarned();
            wonMinigame = false;
        }

        CheckStickers();
    }

    public void CheckStickers()
    {
        stickersEarned = 0;

        if (repairFurnitureEarned)
        {
            repairFurnitureSticker.SetActive(true);
            stickersEarned++;
        }

        if (sewingEarned)
        {
            sewingSticker.SetActive(true);
            stickersEarned++;
        }

        if (gramaphoneEarned)
        {
            gramaphoneSticker.SetActive(true);
            stickersEarned++;
        }

        if (paintingEarned)
        {
            paintingSticker.SetActive(true);
            stickersEarned++;
        }
        
        if (stickersEarned >= 4)
        {
            completionEarned = true;
            completionSticker.SetActive(true);
            stickersEarned++;
            finishGameButton.GetComponent<Button>().interactable = true;
        }
        
        menuText.text = new string(stickersEarned.ToString() + "/5");
        menuSlider.value = stickersEarned;
    }

    public void ManualTriggerEarned()
    {
        CheckStickers();
        StickerEarned();
    }

    public void StickerEarned()
    {
        stickerEarnedPopup.GetComponent<UIFloatAnimation>().IntroAnimation();
    }
    
    public void WonCleaning(bool won)
    {
        if (!gramaphoneEarned)
        {
            gramaphoneEarned = won;
            stickersEarned++;
            ManualTriggerEarned();
            cleaningManager.cleaningGameEndEvent -= WonCleaning;
        }
    }
    
    public void WonRepair(bool won)
    {
        if (!repairFurnitureEarned)
        {
            repairFurnitureEarned = won;
            stickersEarned++;
            ManualTriggerEarned();
        }
    }
}
