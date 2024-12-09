// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 05/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class NailInteract : MonoBehaviour
{
    public Hammer hammer;
    public GameObject powerGauge;
    public GameObject hammerPrefab;
    public GameObject hammerPos;

    public GameObject IdleNail;
    public GameObject SuccessNail;
    public GameObject FailNail;

    public FurnitureRepair manager;

    public Collider nailCollider;
    public ParticleSystem prompt;

    public UISFX sfxManager;
    
    public bool inputEnabled;
    public bool interacted;
    public bool nailSet;
    public float speed;
    
    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
        inputEnabled = true;
    }
    
    public void Interact()
    {
        manager.interacting = true;
        interacted = true;
        prompt.Clear();
        prompt.Stop();
        inputEnabled = false;
        
        IdleNail.SetActive(true);
        powerGauge.SetActive(true);
        powerGauge.GetComponent<UIScaleAnimation>().IntroAnimation();
        powerGauge.GetComponent<PowerGauge>().isActive = true;
        powerGauge.GetComponent<PowerGauge>().Init();
        sfxManager.FurnitureSound();
    }
    
            
    private void NailHit(bool success)
    {
        if (nailSet == false)
        {
            if (interacted)
            {
                IdleNail.SetActive(false);
                powerGauge.GetComponent<PowerGauge>().isActive = false;
                powerGauge.GetComponent<UIScaleAnimation>().OutroWithDelay(0.5f);

                if (success)
                {
                    SuccessNail.SetActive(true);
                }

                if (success == false)
                {
                    FailNail.SetActive(true);
                }

                nailSet = true;
                nailCollider.enabled = false;
                manager.interacting = false;
            }

        }

    }

    IEnumerator DeleteHammer()
    {
        yield return new WaitForSeconds(1);
        hammerPrefab.SetActive(false);
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent += NailHit;
        inputEnabled = false;
    }

    public void Reset()
    {
        SuccessNail.SetActive(false);
        FailNail.SetActive(false);
        IdleNail.SetActive(true);
        nailSet = false;
        inputEnabled = false;
        interacted = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }
}
