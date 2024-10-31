using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public AddCollider addCollider;

    public Vector3[] genPoints = new Vector3[10];
    public GameObject linePoint;

    private void Start()
    {
        CreateLine();
        
    }

    void CreateLine()
    {
        lineRenderer.positionCount = genPoints.Length;
        
        for (int i = 1; i < genPoints.Length; i++)
        {
            genPoints[i] = new Vector3(Random.Range(-1f,1f),0,i);
            
            //Instantiate(linePoint, genPoints[i], Quaternion.identity);
            
            lineRenderer.SetPosition(i,genPoints[i]);

        }
        
        addCollider.GenerateMeshCollider();
        
        
    }
}
