using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBase : MonoBehaviour
{
    public Painting painting;
    public Camera cam;

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
                }

            }
        }
    }
}
