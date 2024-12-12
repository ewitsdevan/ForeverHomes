// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 05/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FurnitureRepair : FurnitureBase
{

    public GameObject mainCamera;
    private RaycastHit hitInfo;
    public GameObject[] nailPoints;
    public GameObject nailParent;
    
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

    public GameObject collider;
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
    public TextMeshProUGUI score;
    public Slider scoreSlider;

    public bool interacting = false;

    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
        scoreSlider.value = successfulHitCount;
        scoreSlider.maxValue = winThreshold;
        score.text = new string(successfulHitCount + "/" + winThreshold);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !book.activeSelf)
        {
            if (Physics.Raycast(mainCamera.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (gameStarted == false)
                {
                    if (hitInfo.collider.gameObject == collider)
                    {
                        Launch();
                    }
                }
                else if (gameStarted && !interacting)
                {
                    // For selecting nails
                    foreach (GameObject nail in nailPoints)
                    {
                        if (hitInfo.collider.gameObject == nail)
                        {
                            // If nail is the one clicked
                            nail.GetComponent<NailInteract>().Interact();
                        }
                        else
                        {
                            // Every other nail is ensured to not be listening and unclickable
                            if (!nail.GetComponent<NailInteract>().nailSet)
                            {
                                nail.GetComponent<NailInteract>().interacted = false;
                                nail.GetComponent<SphereCollider>().enabled = false;
                            }
                        }
                    }
                }
            }
        }
    }
    
    public void Launch()
    {
        // Play Sound
        sfxManager.FurnitureSound();
        
        // Setup Game
        collider.GetComponent<MeshCollider>().enabled = false;
        
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
            gameObject.transform.DOLocalRotate(objectRotation, rotateSpeed).SetDelay(0.25f).OnComplete(ShowUI).SetEase(Ease.InOutBack);
        }).SetEase(Ease.OutSine);
    }

    void ShowUI()
    {
        // Show UI Panel
        minigamePanel.SetActive(true);
        tutorialPanel.GetComponent<UIScaleAnimation>().IntroAnimation();
    }

    public void BeginGame()
    {
        gameStarted = true;
        nailParent.SetActive(true);
        
        for (int i = 0; i < nailPoints.Length; i++)
        {
            nailPoints[i].GetComponent<NailInteract>().inputEnabled = true;
            nailPoints[i].GetComponent<SphereCollider>().enabled = true;
        }
        
        maxHitCount = nailPoints.Length;
    }
    
    void NailHit(bool success)
    {
        if (interacting)
        {
            // Hammer strike VFX
            hammerStrike.Play();
        
            if (success)
            {
                sfxManager.HammerHitSound();
                //nailPosition.SuccessfulHit();
                successfulHitCount++;
                curHitCount++;
                score.text = new string(successfulHitCount + "/" + winThreshold);
                scoreSlider.value = successfulHitCount;
            }
            else
            {
                sfxManager.HammerMissSound();
                //nailPosition.FailedHit();
                curHitCount++;
                score.text = new string(successfulHitCount + "/" + winThreshold);
                scoreSlider.value = successfulHitCount;
            }
        
            // Turn back on colliders after hitting a nail
            foreach (GameObject nail in nailPoints)
            {
                if (nail.GetComponent<NailInteract>().interacted == false)
                {
                    nail.GetComponent<SphereCollider>().enabled = true;
                }
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
                
                scoreSlider.GetComponent<UIFloatAnimation>().OutroAnimation();
                Reset();
            }
        }
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent -= NailHit;
    }

    public void Reset()
    {
        // Rotate chair back
        gameObject.transform.DOLocalRotate(startRotation, rotateSpeed).SetDelay(1.0f).OnComplete(FinishGame).SetEase(Ease.InOutBack);
    }

    void FinishGame()
    {
        // Reset Repair minigame for replayability
        curHitCount = 0;
        gameStarted = false;
        foreach (GameObject nail in nailPoints)
        {
            nail.GetComponent<NailInteract>().Reset();
        }
        nailParent.SetActive(false);
        collider.GetComponent<MeshCollider>().enabled = true;
        
        // Reenables player camera controls via Reset
        mainCamera.GetComponent<IsometricCamera>().Reset();
        
        // Reset and Disable UI
        minigamePanel.SetActive(false);
        
        // Change Controls UI
        hammerControls.GetComponent<UIFloatAnimation>().OutroAnimation();
        cameraControls.GetComponent<UIFloatAnimation>().IntroWithDelay(1f);
        bookButton.IntroAnimation();
    }
}
