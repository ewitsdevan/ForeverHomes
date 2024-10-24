using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraMovement : MonoBehaviour
{
      
       public Camera mainCamera;

       public GameObject furniture;

       public Vector3 startPos;


       private void Start()
       {
              startPos = mainCamera.transform.position;
              
       }

       public void SetCamera(GameObject objectClicked)
       {
              objectClicked = furniture;
              mainCamera.transform.position = furniture.gameObject.transform.GetChild(0).position;
       }

       public void ResetCamera()
       {
              mainCamera.transform.position = startPos;
       }
}
