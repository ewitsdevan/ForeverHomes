using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float maxTime = 10f;
    
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            Debug.Log("Reset");
            currentTime = 0;
        }
        
        
    }

    
    
    
}
