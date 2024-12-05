// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 05/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FurnitureRepair : FurnitureBase
{

    public GameObject mainCamera;
    private RaycastHit hitInfo;
    public GameObject[] nailPoints;
    
    public Vector3 startRotation;
    public Vector3 objectRotation;
    public Vector3 cameraPosition;
    public float cameraZoom;
    public bool gameStarted;
    public float rotateSpeed;
    public float viewSpeed;
    
    public float successfulHitCount;
    public float maxHitCount;
    private float curHitCount;
    public float winThreshold;

    public GameObject minigamePanel;
    public GameObject gaugeMeter;
    public GameObject tutorialPanel;
    public GameObject successText;
    public GameObject failText;
    public UIStickerManager stickerManager;
    public GameObject cameraControls;
    public GameObject hammerControls;
    public ParticleSystem confetti;
    public ParticleSystem hammerStrike;
    public UISFX sfxManager;
    public UIScaleAnimation bookButton;
    public GameObject book;

    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !book.activeSelf)
        {
            if (Physics.Raycast(mainCamera.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo) &&
                gameStarted == false)
            {
                if (hitInfo.collider.GetComponentInParent<FurnitureBase>() != null)
                {
                    Launch();
                }

            }
        }
    }
    
    public void Launch()
    {
        // Play Sound
        sfxManager.FurnitureSound();
        
        gameStarted = true;
        //startPos = mainCamera.transform;
        
        // Change Controls UI
        cameraControls.GetComponent<UIFloatAnimation>().OutroAnimation();
        hammerControls.GetComponent<UIFloatAnimation>().IntroWithDelay(1f);
        bookButton.OutroAnimation();
        
        // Reset Camera
        mainCamera.GetComponent<IsometricCamera>().Reset();
        
        SetCamera();
    }

    void SetCamera()
    {
        // Disable player camera controls
        mainCamera.GetComponent<IsometricCamera>().inMinigame = true;
        
        //set new camera position for game
        mainCamera.transform.DOMove(cameraPosition, 0.4f).OnComplete(() =>
        {
            // Zooms camera using existing camera system
            mainCamera.GetComponent<IsometricCamera>().minigameZoom = cameraZoom;
            
            //rotate chair
            gameObject.transform.DOLocalRotate(objectRotation, rotateSpeed).SetDelay(0.25f).OnComplete(BeginGame).SetEase(Ease.InOutBack);
        }).SetEase(Ease.OutSine);
    }

    void BeginGame()
    {

        for (int i = 0; i < nailPoints.Length; i++)
        {
            nailPoints[i].SetActive(true);
        }
        
        maxHitCount = nailPoints.Length;
        
        // Show UI Panel
        minigamePanel.SetActive(true);
        minigamePanel.GetComponent<UIScaleAnimation>().IntroAnimation();
        
    }
    
    void NailHit(bool success)
    {
        // Hammer strike VFX
        hammerStrike.Play();
        
        if (success)
        {
            sfxManager.HammerHitSound();
            //nailPosition.SuccessfulHit();
            successfulHitCount++;
            curHitCount++;
        }

        if (success == false)
        {
            sfxManager.HammerMissSound();
            //nailPosition.FailedHit();
            curHitCount++;
        }

        if (curHitCount >= maxHitCount)
        {
            //finish game
            if (successfulHitCount >= winThreshold)
            {
                //win game
                Debug.Log("you have won");
                stickerManager.WonRepair(true);
                
                // Show success UI
                successText.GetComponent<UIScaleAnimation>().IntroAnimation();
                confetti.Play();
                sfxManager.ConfettiSound();
            }
            else
            {
                //lose game
                Debug.Log("you have lost");
                
                // Show failure UI
                failText.GetComponent<UIScaleAnimation>().IntroAnimation();
            }
            
            // Rotate chair back
            gameObject.transform.DOLocalRotate(startRotation, rotateSpeed).SetDelay(1.0f).OnComplete(FinishGame).SetEase(Ease.InOutBack);
            
        }
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent -= NailHit;
    }

    void FinishGame()
    {
        // Reenables player camera controls via Reset
        mainCamera.GetComponent<IsometricCamera>().Reset();
        
        // Reset and Disable UI
        gaugeMeter.SetActive(false);
        tutorialPanel.SetActive(true);
        minigamePanel.SetActive(false);
        
        // Change Controls UI
        hammerControls.GetComponent<UIFloatAnimation>().OutroAnimation();
        cameraControls.GetComponent<UIFloatAnimation>().IntroWithDelay(1f);
        bookButton.IntroAnimation();
    }
}
