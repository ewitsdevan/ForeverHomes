// Created by Devan Laczko, 30/09/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuitButton : MonoBehaviour
{
    // Quits Game
    public void Quit()
    {
        print("UIQuitButton: Quit");
        Application.Quit();
    }
}
