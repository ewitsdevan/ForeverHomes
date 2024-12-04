using UnityEngine;

public class Painting : MonoBehaviour
{

   public CleanableObj grass;
   public CleanableObj flower;
   public CleanableObj sky;

   public GameObject paintInput;

   public int selectedColour;

   private  RaycastHit hitInfo;
   
   public Camera cam;

   public delegate void PaintingGameEndEvent(bool hasWon);

   public event PaintingGameEndEvent paintingGameEndEvent;


   private void Start()
   {
      sky.enabled = false;
      grass.enabled = false;
      flower.enabled = false;

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
               //Debug.Log("Test");
               int selectedObj = hitInfo.collider.GetComponentInChildren<PaintedObject>().objectName;
               CanWeColour(selectedObj);
               paintInput.SetActive(true);
            }

         }
      }


   }

   public void CanWeColour(int selectedObj)
   {
      if (selectedObj == selectedColour)
      {
         sky.enabled = false;
         grass.enabled = false;
         flower.enabled = false;
         
         if(selectedObj == 0)
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
      }
      else
      {
         //not able to paint, add particle effect?
      }

   }

   void WinCheck()
   {
      if (grass.isClean == true && flower.isClean == true && sky.isClean == true)
      {
         paintingGameEndEvent?.Invoke(true);
      }
   }
   
   
   
   
}