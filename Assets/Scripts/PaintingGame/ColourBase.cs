using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBase : MonoBehaviour
{
    public Painting painting;
    public Camera cam;
    
    public GameObject paintBrush;
    public Sprite lightGreen;
    public Sprite blue;
    public Sprite darkGreen;
    public Sprite pink;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.GetComponent<ColourSelect>() != null)
                {
                    painting.selectedColour = hitInfo.collider.GetComponent<ColourSelect>().myColour;

                    if (painting.selectedColour == 0)
                    {
                        paintBrush.GetComponent<SpriteRenderer>().sprite = darkGreen;
                    }

                    if (painting.selectedColour == 1)
                    {
                        paintBrush.GetComponent<SpriteRenderer>().sprite = pink;
                    }
                    
                    if (painting.selectedColour == 2)
                    {
                        paintBrush.GetComponent<SpriteRenderer>().sprite = blue;
                    }
                    
                    if (painting.selectedColour == 3)
                    {
                        paintBrush.GetComponent<SpriteRenderer>().sprite = lightGreen;
                    }
                }

            }
        }
    }
}
