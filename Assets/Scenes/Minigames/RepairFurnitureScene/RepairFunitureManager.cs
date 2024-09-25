using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairFunitureManager : MonoBehaviour
{
    //Game Manager for repair furniture mini game

    public StateManager stateManager;
    public IdleState idleState;

    private void Start()
    {
        stateManager.currentState = idleState;
    }
    
    
}
