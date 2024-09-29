 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 using UnityEngine.Serialization;
 using Random = UnityEngine.Random;

public class RhythmManager : MonoBehaviour
{
    public Timer timer;

    public int numberOfNails = 4;
    public int[] rhythmPoints;
    public int nailPostion;

    public GameObject nail;
    
    // Start is called before the first frame update
    void Start()
    {
        rhythmPoints = new int[numberOfNails];
        SetRhythmPoints();
    }
    
    
    void SetRhythmPoints()
    {
        //Setting random value for four points in rhythm
        for (int i = 0; i < rhythmPoints.Length; i++)
        {
            rhythmPoints[i] = Random.Range(0, nailPostion);
            Instantiate(nail, new Vector3(rhythmPoints[i], 0, 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        /*
        if (timer.currentTime >= rhythmPoints[nextPointIndex] + or - 0.5)
        {
            nextPointIndex++
        }
    */
    }
}
