using System;
using System.Collections;
using UnityEngine;

public class Painting : MonoBehaviour
{

   public CleanableObj grass;
   public CleanableObj flower;
   public CleanableObj sky;
   public CleanableObj stem;

   public GameObject paintInput;

   public int selectedColour;

   private  RaycastHit hitInfo;
   
   public Camera cam;

   public delegate void PaintingGameEndEvent(bool hasWon);

   public event PaintingGameEndEvent paintingGameEndEvent;

   private bool once;

   public void Start()
   {
      StartCoroutine(GameBegins());
   }

   IEnumerator GameBegins()
   {
      yield return new WaitForSeconds(3f);
      
      sky.gameStarted = true;
      grass.gameStarted = true;
      flower.gameStarted = true;
      stem.gameStarted = true;
      
      sky.enabled = false;
      grass.enabled = false;
      flower.enabled = false;
      stem.enabled = false;
   }

   private void Update()
   {
      if(Input.GetMouseButtonDown(0))
      {
        paintInput.SetActive(false);
         if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo))
         {
            if (hitInfo.collider.GetComponentInChildren<PaintedObject>() != null)
            {
               int selectedObj = hitInfo.collider.GetComponentInChildren<PaintedObject>().objectName;
               CanWeColour(selectedObj);
            }
         }
      }

      if (!once)
      {
         WinCheck();
      }
   }

   public void CanWeColour(int selectedObj)
   {
      if (selectedObj == selectedColour)
      {
         sky.enabled = false;
         grass.enabled = false;
         flower.enabled = false;
         stem.enabled = false;
         paintInput.SetActive(true);

         if (selectedObj == 0)
         {
            grass.enabled = true;

            if (grass.isClean == true)
            {
               WinCheck();
            }

         }

         if (selectedObj == 1)
         {
            flower.enabled = true;

            if (flower.isClean == true)
            {
               WinCheck();
            }
         }

         if (selectedObj == 2)
         {
            sky.enabled = true;

            if (sky.isClean == true)
            {
               WinCheck();
            }
         }

         if (selectedObj == 3)
         {
            stem.enabled = true;

            if (stem.isClean == true)
            {
               WinCheck();
            }
         }

      }
   } 
   
   void WinCheck() 
   {
      if (grass.isClean == true && flower.isClean == true && sky.isClean == true && stem.isClean == true)
      {
         paintingGameEndEvent?.Invoke(true);
         once = true;
      }
   }
}
