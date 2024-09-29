using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HitState : StateBase
{
    public StateManager stateManager;

    public IdleState idleState;
    

    private void OnEnable()
    {
        idleState.hittable = true;
    }
    


    private void OnDisable()
    {
        idleState.hittable = false;
    }
}
