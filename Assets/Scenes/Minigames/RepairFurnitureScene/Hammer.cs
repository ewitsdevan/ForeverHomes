using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class Hammer : MonoBehaviour
{
    public SplineContainer splineContainer;
    
    public float speed = 0.5f;

    public float timeSinceLevelLoaded;
    public Timer timer;

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelLoaded = (timer.currentTime * speed) % 1f;
        float3 position = splineContainer.EvaluatePosition(timer.currentTime);
        transform.rotation = Quaternion.Euler(splineContainer.EvaluateTangent(timer.currentTime));
        transform.position = position;
    }
}
