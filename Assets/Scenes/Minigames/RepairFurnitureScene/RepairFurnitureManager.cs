using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RepairFurnitureManager : MonoBehaviour
{
    public NailPosition nailPosition;
    public NailTrack nailTrack;
    public PlayerInput playerInput;
    public LineRenderer lineRenderer;

    public float successfulHitCount;
    public float maxHitCount;
    private float curHitCount;
    public float winThreshold;




    //  public CinemachineVirtualCamera virtualCam;
    //  public CinemachineSmoothPath smoothPath;
    public Camera mainCam;

    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
    }


    [Button]
    public void BeginGame()
    {
        lineRenderer.enabled = true;
        nailTrack.CreateNailTrack();
        playerInput.enabled = true;

    }

    void NailHit(bool success)
    {
        if (success)
        {
            nailPosition.SuccessfulHit();
            successfulHitCount++;
            curHitCount++;
        }

        if (success == false)
        {
            nailPosition.FailedHit();
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

            playerInput.enabled = false;
            //back to main scene
        }
        
        //zoom camera back out
        playerInput.enabled = true;
    }
    
    
    
    void CameraMove()
    {
        //camMovement.SetPath(section);
        
        //virtualCam.LookAt = nailObj.transform;
        // smoothPath.m_Waypoints[0].position = mainCam.transform.position;
        //smoothPath.m_Waypoints[1].position = nailObj.transform.GetChild(2).position;

    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent -= NailHit;
    }
}
