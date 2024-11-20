// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 24/10/2024

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
    
    private Vector3 startPos;
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
    public GameObject outcomePanel;
    public UIStickerManager stickerManager;

    private bool hasCompleted;

    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
        startPos = gameObject.transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasCompleted)
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
        gameStarted = true;
        //startPos = mainCamera.transform;
        
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
        
    }
    
    void NailHit(bool success)
    {
        if (success)
        {
            //nailPosition.SuccessfulHit();
            successfulHitCount++;
            curHitCount++;
        }

        if (success == false)
        {
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
                UIStickerManager.repairFurnitureEarned = true;
                UIStickerManager.stickersEarned++;
                stickerManager.ManualTriggerEarned();
                
                // Show success UI
                gaugeMeter.SetActive(false);
                tutorialPanel.SetActive(false);
                successText.SetActive(true);
                outcomePanel.SetActive(true);
            }
            else
            {
                //lose game
                Debug.Log("you have lost");
                
                // Show failure UI
                gaugeMeter.SetActive(false);
                tutorialPanel.SetActive(false);
                failText.SetActive(true);
                outcomePanel.SetActive(true);
            }
            
            // Rotate chair back
            gameObject.transform.DOLocalRotate(startPos, rotateSpeed).SetDelay(1.0f).OnComplete(FinishGame).SetEase(Ease.InOutBack);
            
        }
        
        //zoom camera back out
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
        successText.SetActive(false);
        failText.SetActive(false);
        gaugeMeter.SetActive(false);
        tutorialPanel.SetActive(true);
        minigamePanel.SetActive(false);
        
        // Stops player from playing again
        hasCompleted = true;
    }



}
