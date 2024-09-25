using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.XR;

public class StateManager : MonoBehaviour
{
    public StateBase startingState;
    public StateBase currentState;

    private void OnEnable()
    {
        ChangeState(startingState);
    }

    //works for any state
    public void ChangeState(StateBase newState)
    {
        // Check if the state is the same and DON'T swap
        if (newState == currentState)
        {
            return;
        }

        // At first 'currentstate' will ALWAYS be null
        if (currentState != null)
        {
            currentState.enabled = false;
        }

        newState.enabled = true;

        // New state swap over to incoming state
        currentState = newState;
    }

    private void OnDisable()
    {
        currentState.enabled = false;
    }
    
}
