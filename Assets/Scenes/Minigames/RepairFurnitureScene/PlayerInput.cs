using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 point;
    public Camera mainCam;
    
    public delegate void PlayerAddNailEvent();
    public event PlayerAddNailEvent playerAddNailEvent;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                
                if (hitInfo.collider != null)
                {
                    mousePos = Input.mousePosition;
                    point = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                
                    Debug.Log("nail");
                    Debug.Log(hitInfo.collider);
                    

                    if (playerAddNailEvent != null)
                    {
                        playerAddNailEvent.Invoke();
                    }
                    
                }
                
            }
            
        }
        
    }
    
}
