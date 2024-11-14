using System;
using UnityEngine;

public class PaintedObject : MonoBehaviour
{

    public Camera cam;
    public Sprite colouredObj;
    public Sprite greyObj;

    public SpriteRenderer spriteRenderer;

    public int objectName;

    public Collider2D objCollider;
    public MeshCollider meshCollider;
    
    private RaycastHit hitInfo;

    //Using ints bc easier to compare in main script
    //grass = 0
    //flower = 1
    //sky = 2
    private void Start()
    {
        Mesh mesh = objCollider.CreateMesh(true, true);
        
        meshCollider.sharedMesh = mesh;
        
    }

    public void ColourMe()
    {
        spriteRenderer.sprite = colouredObj;
    }

    public void UnColourMe()
    {
        spriteRenderer.sprite = greyObj;
    }
    
    
    
    
}
