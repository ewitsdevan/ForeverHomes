// Created by Devan Laczko, 19/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UIAutoAnimation>().ExitAnimation();
    }
}
