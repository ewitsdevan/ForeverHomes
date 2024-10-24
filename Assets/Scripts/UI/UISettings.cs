// Created by Devan Laczko, 26/09/2024
// Updated 20/10/2024

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [Space] [Space] [Header("Sound")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private AudioMixer _audioMixer;

    [Space] [Space] [Header("Display")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private Toggle _vsyncToggle;
    private Resolution[] _resolutions;

    [Space] [Space] [Header("Graphics")]
    [SerializeField] private TMP_Dropdown _qualityDropdown;
    
    [Space] [Space] [Header("Version")]
    [SerializeField] private TextMeshProUGUI _versionText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set Current Settings Values
        
        // Audio
        _audioMixer.GetFloat("Music", out float _musicValue);
        _musicSlider.value = _musicValue;
        _audioMixer.GetFloat("SFX", out float _sfxValue);
        _sfxSlider.value = _sfxValue;

        // Display
        GetResolutions();
        _fullscreenToggle.isOn = Screen.fullScreen;
        _vsyncToggle.isOn = Convert.ToBoolean(QualitySettings.vSyncCount);
        
        // Graphics
        _qualityDropdown.value = QualitySettings.GetQualityLevel();
        
        //Version
        _versionText.text = new string ("Forever Homes (Demo) Version " + Application.version + " " + Application.platform);
    }

    public void ChangeMusicVolume()
    {
        _audioMixer.SetFloat("Music", _musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        _audioMixer.SetFloat("SFX", _sfxSlider.value);
    }

    public void GetResolutions()
    {
        _resolutionDropdown.ClearOptions();
        _resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);
            if(_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void ChangeResolution(int resolutionIndex)
    {
        resolutionIndex = _resolutionDropdown.value;
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeFullscreenMode()
    {
        Screen.fullScreen = _fullscreenToggle.isOn;
    }

    public void ChangeVsyncMode()
    {
        QualitySettings.vSyncCount = Convert.ToInt32(_vsyncToggle.isOn);
    }

    public void ChangeQualityLevel()
    {
        QualitySettings.SetQualityLevel(_qualityDropdown.value);
    }
}
