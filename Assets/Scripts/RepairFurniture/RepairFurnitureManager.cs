using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RepairFurnitureManager : MonoBehaviour
{
    public NailPosition nailPosition;
    public PlayerInput playerInput;
    

    public float successfulHitCount;
    public float maxHitCount;
    private float curHitCount;
    public float winThreshold;

    public delegate void RepairGameEndEvent(bool hasWon);

    public event RepairGameEndEvent repairGameEndEvent;


    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
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
                repairGameEndEvent?.Invoke(true);
            }
            else
            {
                repairGameEndEvent?.Invoke(false);
            }

            playerInput.enabled = false;
            //back to main scene
        }
        
        //zoom camera back out
        playerInput.enabled = true;
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent -= NailHit;
    }
}
