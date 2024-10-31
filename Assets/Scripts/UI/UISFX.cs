// Created by Devan Laczko, 20/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISFX : MonoBehaviour
{
    public AudioClip buttonClickClip;
    public AudioClip pageFlipClip;

    private AudioSource _audioSource;

    public void ButtonClickSound()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = buttonClickClip;
        _audioSource.Play();
    }
    
    public void PageFlipSound()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = pageFlipClip;
        _audioSource.Play();
    }
}
