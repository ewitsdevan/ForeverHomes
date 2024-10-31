using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

public class SplineCurve : MonoBehaviour
{
    public SplineContainer splineContainer;

    public float newPosition;
    public int[] splineKnots;
    private void Start()
    {
        splineKnots = new int[splineContainer.Spline.Count];
        SetKnots();
    }

    void SetKnots()
    {
        if (splineContainer != null && splineContainer.Spline != null)
        {
            for (int i = 1; i < splineKnots.Length; i++ )
            {
                //setting x value for spline knot to create random curves along spline
                BezierKnot knot = splineContainer.Spline[i];
                knot.Position.x = newPosition;
                newPosition = Random.Range(-0.1f, 0.1f);
                splineContainer.Spline.SetKnot(i, knot);
            }
        }
    }
    
    
    
    public void Update()
    {
        
        
        
        
    }
}
