using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CleaningManager : MonoBehaviour
{
    public delegate void CleaningGameEndEvent(bool hasWon);
    public event CleaningGameEndEvent cleaningGameEndEvent;

    public CleanableObj cleanableObj;
    public GameObject objectToMove;

    public GameObject camera;
    public Vector3 cameraPosition;
    public float cameraZoom;

    public Vector3 startPosition;
    public Vector3 objectPosition;
    public Vector3 startRotation;
    public Vector3 objectRotation;
    public float moveSpeed;

    public GameObject minigamePanel;
    public GameObject tutorialPanel;
    public UIFloatAnimation cameraControls;
    public GameObject successText;
    public UIScaleAnimation bookButton;
    
    public ParticleSystem confetti;
    public UISFX sfxManager;

    private bool gameStarted;
    private bool once;

    public GameObject book;

    void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted && !book.activeSelf)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(camera.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.gameObject == cleanableObj.gameObject)
                {
                    gameStarted = true;
                    Launch();
                }
            }
        }
        
        if (cleanableObj.isClean && !once)
        {
            once = true;
            
            // Earn Sticker
            cleaningGameEndEvent?.Invoke(true);
            
            // Show success UI
            successText.GetComponent<UIScaleAnimation>().IntroAnimation();
            confetti.Play();
            sfxManager.ConfettiSound();
            
            // Rotate record back
            objectToMove.transform.DOLocalRotate(startRotation, moveSpeed).SetDelay(1.0f);
            objectToMove.transform.DOLocalMove(startPosition, moveSpeed).SetDelay(1.0f).OnComplete(FinishGame).SetEase(Ease.InOutBack);
        }
    }
    
    public void Launch()
    {
        // Play Sound
        sfxManager.FurnitureSound();
        
        // Change Controls UI
        cameraControls.OutroAnimation();
        bookButton.OutroAnimation();
        
        // Reset Camera
        camera.GetComponent<IsometricCamera>().Reset();
        
        SetCamera();
    }

    void SetCamera()
    {
        // Disable player camera controls
        camera.GetComponent<IsometricCamera>().inMinigame = true;
        
        //set new camera position for game
        camera.gameObject.transform.DOMove(cameraPosition, 0.4f).OnComplete(() =>
        {
            // Zooms camera using existing camera system
            camera.GetComponent<IsometricCamera>().minigameZoom = cameraZoom;
            
            // Move Object
            objectToMove.transform.DOLocalMove(objectPosition, moveSpeed);
            objectToMove.transform.DOLocalRotate(objectRotation, moveSpeed).SetDelay(0.25f).OnComplete(ShowUI).SetEase(Ease.InOutBack);
        }).SetEase(Ease.OutSine);
    }

    void ShowUI()
    {
        // Show UI Panel
        minigamePanel.SetActive(true);
        minigamePanel.GetComponent<UIScaleAnimation>().IntroAnimation();
    }

    public void BeginGame()
    {
        cleanableObj.gameStarted = true;
    }
    
    
    
    void FinishGame()
    {
        // Reenables player camera controls via Reset
        camera.GetComponent<IsometricCamera>().Reset();
        
        // Reset and Disable UI
        tutorialPanel.SetActive(true);
        minigamePanel.SetActive(false);
        
        // Change Controls UI
        cameraControls.GetComponent<UIFloatAnimation>().IntroWithDelay(1f);
        bookButton.IntroAnimation();
    }
}
