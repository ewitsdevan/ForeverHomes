using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    public StateManager stateManager;

    public IdleState idleState;

    public bool hittable;

    private void OnEnable()
    {
        hittable = false;
        
    }

    private void OnDisable()
    {
        
    }
}
