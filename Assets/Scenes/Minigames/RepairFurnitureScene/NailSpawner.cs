using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

public class NailSpawner : MonoBehaviour
{
    public SplineInstantiate splineInstantiate;
    public SplineContainer splineContainer;


    private void Awake()
    {
        splineInstantiate.Seed = Random.Range(-1000, 10000);

    }

    private void Update()
    {
        Debug.Log(splineInstantiate.Container.gameObject.transform.position);
    }
}
