// Created by Devan Laczko, 30/09/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButton : MonoBehaviour
{
    public GameObject targetMenu;
    public GameObject otherMenu;

    public void ChangeMenu()
    {
        if (otherMenu.activeSelf == true)
        {
            StartCoroutine(HideCurrentMenu());
        }
        else
        {
            targetMenu.SetActive(true);
            targetMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
        }
    }

    IEnumerator HideCurrentMenu()
    {
        otherMenu.GetComponent<UIAutoAnimation>().ExitAnimation();
        yield return new WaitForSeconds(0.25f);
        otherMenu.SetActive(false);
        
        targetMenu.SetActive(true);
        targetMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
    }
}
