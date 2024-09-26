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
    void Start()
    {
        HideBook();
    }
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
    }

    private void HideBook()
    {
        gameObject.SetActive(false);
    }
}
