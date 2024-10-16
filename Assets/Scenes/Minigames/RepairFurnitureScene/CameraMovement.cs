using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
       // public CinemachineSmoothPath path;
       // public CinemachineDollyCart dollyCart;
        public NailPosition nailPosition;
        public Camera mainCamera;

        public Transform startPoint;
        public Vector3 zoomPoint;
        public float time = 0.5f;

        public void SetPath(int section)
        {
            
            mainCamera.enabled = false;
            startPoint = transform;
            zoomPoint = new Vector3(nailPosition.nailPos.x, startPoint.position.y, startPoint.position.z);
                gameObject.transform.position = zoomPoint;






        }
}
