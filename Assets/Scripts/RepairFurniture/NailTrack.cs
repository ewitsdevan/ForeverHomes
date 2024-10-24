using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NailTrack : MonoBehaviour
{
    public LineRenderer line;
    public AddCollider addCollider;

    public GameObject[] point;
    
    public void CreateNailTrack()
    {
        line.positionCount = point.Length;
        line.loop = false;

        for(int i = 0; i < point.Length; i++)
        {
            line.SetPosition(i,point[i].transform.position);
        }
        
        addCollider.GenerateMeshCollider();
        
    }

    private void Update()
    {
        
    }
}
