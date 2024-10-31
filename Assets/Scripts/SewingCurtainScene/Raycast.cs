using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public SewingGameManager manager;
    
    
    private void Update()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, Vector3.down, out hitInfo, 10f))
        {
            //Debug.Log("Hit");
            if (hitInfo.collider != null)
            {
                //Debug.Log(hitInfo.collider);
                manager.sewingScore++;

            }
        }
        
        //Debug.DrawLine(transform.position,Vector3.down * 10f);

        
    }
}
