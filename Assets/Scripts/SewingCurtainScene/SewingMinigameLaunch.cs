// Created by Devan Laczko 09/11/2024

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SewingMinigameLaunch : MonoBehaviour
{
    public GameObject mainCamera;
    private RaycastHit hitInfo;
    public Vector3 cameraPosition;
    public float cameraZoom;
    private bool gameStarted;
    public GameObject loadingPanel;
    
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mainCamera.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition), out hitInfo) &&
                gameStarted == false)
            {
                //Launch();
                if (hitInfo.collider.gameObject == gameObject)
                {
                    Launch();
                }

            }
        }
    }
    
    public void Launch()
    {
        gameStarted = true;
        
        // Reset Camera
        mainCamera.GetComponent<IsometricCamera>().Reset();
        
        SetCamera();
        StartCoroutine(LoadGame());
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
        }).SetEase(Ease.OutSine);
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1.0f);
        loadingPanel.SetActive(true);
        loadingPanel.GetComponent<UILoading>().LoadSewingMinigame();
    }
}
