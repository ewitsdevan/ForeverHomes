 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RhythmManager : MonoBehaviour
{
    public Timer timer;
    
    public int[] rhythmPoints = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        SetRhythmPoints();
    }
    
    
    void SetRhythmPoints()
    {
        //Setting random value for four points in rhythm
        rhythmPoints[0] = Random.Range(1, 2);
        rhythmPoints[1] = Random.Range(3, 5);
        rhythmPoints[2] = Random.Range(6, 7);
        rhythmPoints[3] = Random.Range(8, 10);
    }

    private void Update()
    {
        //if (timer.currentTime = rhythm points value + or - 0.5)
       // {
            
       // }
    }
}
