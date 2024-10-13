using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour
{
    public LineRenderer line;
    
    public void GenerateMeshCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, true);
        collider.sharedMesh = mesh;
        

    }
    
    
    
}
