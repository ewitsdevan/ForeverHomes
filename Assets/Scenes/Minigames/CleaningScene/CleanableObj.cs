using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanableObj : MonoBehaviour
{
    
    public Texture2D dirtMask;
    public Texture2D dirtBrush;
    public Camera mainCam;

    void Update()
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            //uv coords where raycast hits
            Vector2 textureCoord = hitInfo.textureCoord;

            int pixelX = (int)(textureCoord.x * dirtMask.width);
            int pixelY = (int)(textureCoord.y * dirtMask.height);

            Vector2Int paintPixelPos = new Vector2Int(pixelX, pixelY);
            Debug.Log("UV: "+ textureCoord + " ; Pixels: " + paintPixelPos);

            int pixelXOffset = pixelX - (dirtBrush.width / 2);
            int pixelYOffset = pixelY - (dirtBrush.height / 2);
            
            for(int x = 0; x <dirtBrush.width; x++)
            {
                for (int y = 0; y < dirtBrush.height; y++)
                {
                    Color pixelDirt = dirtBrush.GetPixel(x, y);
                    Color pixelDirtMask = dirtMask.GetPixel(pixelXOffset + x, pixelYOffset + y);
                    
                    dirtMask.SetPixel(pixelXOffset + x, pixelYOffset + y, new Color(0,pixelDirtMask.g,pixelDirt.g,0));
                }
                
            }
            dirtMask.Apply();

        }



    }
}
