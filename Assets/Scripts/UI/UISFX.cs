// Created by Devan Laczko, 20/10/2024

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISFX : MonoBehaviour
{
    public AudioClip buttonClickClip;
    public AudioClip pageFlipClip;
    public AudioClip hammerClip;
    public AudioClip confettiClip;
    public AudioClip furnitureClip;
    public AudioClip rustleClip;
    public AudioClip catClip;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ButtonClickSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = buttonClickClip;
        _audioSource.Play();
    }
    
    public void PageFlipSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = pageFlipClip;
        _audioSource.Play();
    }

    public void OpenBookSound()
    {
        _audioSource.pitch = 1.25f;
        _audioSource.clip = pageFlipClip;
        _audioSource.Play();
    }

    public void CloseBookSound()
    {
        _audioSource.pitch = 0.75f;
        _audioSource.clip = pageFlipClip;
        _audioSource.Play();
    }

    public void HammerHitSound()
    {
        _audioSource.pitch = 1.2f;
        _audioSource.clip = hammerClip;
        _audioSource.Play();
    }
    
    public void HammerMissSound()
    {
        _audioSource.pitch = 0.8f;
        _audioSource.clip = hammerClip;
        _audioSource.Play();
    }

    public void ConfettiSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = confettiClip;
        _audioSource.Play();
    }

    public void FurnitureSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = furnitureClip;
        _audioSource.Play();
    }

    public void RustleSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = rustleClip;
        _audioSource.Play();
    }

    public void CatSound()
    {
        _audioSource.pitch = 1.0f;
        _audioSource.clip = catClip;
        _audioSource.Play();
    }
}
