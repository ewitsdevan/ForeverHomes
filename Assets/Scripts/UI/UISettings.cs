// Created by Devan Laczko, 26/09/2024
// Updated 30/09/2024

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UISettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Gets the game's version number, platform specific.
        #if UNITY_EDITOR
            gameObject.GetComponent<TextMeshProUGUI>().text = PlayerSettings.bundleVersion;
        #endif
        
        #if UNITY_STANDALONE
            gameObject.GetComponent<TextMeshProUGUI>().text = Application.version;
        #endif
    }
}
