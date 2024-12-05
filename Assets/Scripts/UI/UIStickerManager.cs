// Created by Devan Laczko, 20/11/2024
// Updated 04/12/2024

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    
    public float popupDuration;
    
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
        if (repairFurnitureEarned) repairFurnitureSticker.SetActive(true);
        if (sewingEarned) sewingSticker.SetActive(true);
        if (gramaphoneEarned) gramaphoneSticker.SetActive(true);
        if (paintingEarned) paintingSticker.SetActive(true);
        if (completionEarned) completionSticker.SetActive(true);

        menuText.text = new string(stickersEarned.ToString() + "/5");
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
}
