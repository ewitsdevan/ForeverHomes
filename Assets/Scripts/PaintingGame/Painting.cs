using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{

   public GameObject grass;
   public GameObject flower;
   public GameObject sky;

   public int selectedColour;
   
   private Color[] colours = new Color[3];
   
   private  RaycastHit hitInfo;
   
   public Camera cam;

   private void Start()
   {
      /*
      colours[0] = new Color(128, 158, 232); //Sky
      colours[1] = new Color(88, 158, 55); //Grass
      colours[2] = new Color(220, 141, 178); //Flower
      */

   }
   private void Update()
   {
      if(Input.GetMouseButtonDown(0))
      {
        
         if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo))
         {
            if (hitInfo.collider.GetComponentInChildren<PaintedObject>() != null)
            {
               //Debug.Log("Test");
               int selectedObj = hitInfo.collider.GetComponentInChildren<PaintedObject>().objectName;
               CanWeColour(selectedObj);
            }

         }
      }


   }

   public void CanWeColour(int selectedObj)
   {
      if (selectedObj == selectedColour)
      {
         //Debug.Log("Can paint");
         hitInfo.collider.GetComponentInChildren<PaintedObject>().ColourMe();
         
         
      }
      else
      {
         //not able to paint, add particle effect?
      }
      
   }
   
   
   
   
   
}
