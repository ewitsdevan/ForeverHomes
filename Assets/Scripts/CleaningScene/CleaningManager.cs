using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningManager : MonoBehaviour
{
    public delegate void CleaningGameEndEvent(bool hasWon);

    public event CleaningGameEndEvent cleaningGameEndEvent;

    public CleanableObj cleanableObj;
    
    void Update()
    {
        if (cleanableObj.isClean)
        {
            cleaningGameEndEvent?.Invoke(true);
        }
    }
}
