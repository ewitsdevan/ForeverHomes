using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleControl : MonoBehaviour
{
    public GenerateLine generateLine;
    public SewingGameManager manager;
    

    public float sewingSpeed;
    public float moveSpeed;
    public Vector3 startingPos = new Vector3(0, 1, 0);
    public Vector3 endPos;

    
    private void Start()
    {
       transform.position = startingPos;
    }
    
    private void Update()
    {
        endPos.z = generateLine.genPoints.Length + startingPos.z;
        if (transform.position.z < endPos.z)
        {
            
            transform.position += Vector3.forward * (Time.deltaTime * sewingSpeed);


            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * moveSpeed;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * moveSpeed;
                
            }
        }
        else
        {
            manager.hasFinished = true;
        }
    }

}
