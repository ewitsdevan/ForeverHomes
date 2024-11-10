// Created by Maddie Thynne 23/10/2024
//Updated by Devan Laczko 08/11/2024

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
    public Vector2 panLimit;

    
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

            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * (moveSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, panLimit.x, panLimit.y), transform.position.y, transform.position.z);


            if (Input.GetKey(KeyCode.A))
            {
                //transform.position += Vector3.left * moveSpeed;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                //transform.position += Vector3.right * moveSpeed;
                
            }
        }
        else
        {
            manager.hasFinished = true;
        }
    }

}
