// Created by Devan Laczko, 26/09/2024
// Updated 30/09/2024

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBook : MonoBehaviour
{
    public void ToggleBook()
    {
        if (gameObject.activeSelf == false)
        {
            ShowBook();
        }
        else
        {
            HideBook();
        }
    }
    
    private void ShowBook()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<UIAutoAnimation>().EntranceAnimation();
    }

    private void HideBook()
    {
        gameObject.GetComponent<UIAutoAnimation>().ExitAnimation();
        StartCoroutine(HideDelay());
    }

    IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
