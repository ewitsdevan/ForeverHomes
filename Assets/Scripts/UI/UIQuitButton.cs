// Created by Devan Laczko, 30/09/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuitButton : MonoBehaviour
{
    public GameObject book;
    // Quits Game
    public void Quit()
    {
        print("UIQuitButton: Quit");
        Application.Quit();
    }

    // Closes Book
    public void Back()
    {
        StartCoroutine(DelayedDisable());
    }

    IEnumerator DelayedDisable()
    {
        yield return new WaitForSeconds(0.5f);
        book.SetActive(false);
    }
}
