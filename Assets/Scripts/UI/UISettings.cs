// Created by Devan Laczko, 26/09/2024
// Updated 30/09/2024

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _versionText;
    
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    
    [SerializeField] private Toggle _vsyncToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the game's version number, platform specific.
        #if UNITY_EDITOR
            _versionText.text = new string ("Forever Homes (Demo) Version " + PlayerSettings.bundleVersion);
        #endif
        
        #if UNITY_STANDALONE
            _versionText.text = new string ("Forever Homes (Demo) Version " + Application.version);
        #endif
    }
}
