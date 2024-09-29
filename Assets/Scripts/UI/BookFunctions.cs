using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class BookFunctions : MonoBehaviour
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
