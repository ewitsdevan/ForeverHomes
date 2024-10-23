using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FurnitureRepair : FurnitureBase
{

    public Camera mainCamera;
    private RaycastHit hitInfo;
    public GameObject[] nailPoints;
    

    private Transform startPos;
    public Vector3 inGamePos;
    public GameObject inGameCameraPos;
    public bool gameStarted;
    public float speed;
    public float viewSpeed;
    
    public float successfulHitCount;
    public float maxHitCount;
    private float curHitCount;
    public float winThreshold;

    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo) &&
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
        //Get original camera position
        mainCamera.enabled = true;
        //startPos = mainCamera.transform;
        
        //rotate chair
        gameObject.transform.DOLocalRotate(inGamePos, speed).OnComplete(SetCamera).SetEase(Ease.InOutBack);
    }

    void SetCamera()
    {
        //set new camera position for game
        mainCamera.transform.DOMove(inGameCameraPos.transform.position, 0.4f).SetDelay(0.2f).OnComplete(() =>
        {
            mainCamera.transform.DOLookAt(gameObject.transform.position, viewSpeed).OnComplete(() =>
            {
                BeginGame();
                
            }).SetEase(Ease.OutCirc);
        }).SetEase(Ease.OutSine);
    }

    void BeginGame()
    {

        for (int i = 0; i < nailPoints.Length; i++)
        {
            nailPoints[i].SetActive(true);
        }
        
        maxHitCount = nailPoints.Length;
        
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
            }
            else
            {
                //lose game
                Debug.Log("you have lost");
            }

            //set camera to original position

            
            //back to main scene
        }
        
        //zoom camera back out
        mainCamera.enabled = true;
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent -= NailHit;
    }



}
