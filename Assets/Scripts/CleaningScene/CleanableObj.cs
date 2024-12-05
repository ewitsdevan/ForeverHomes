using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class CleanableObj : MonoBehaviour
{
    public Texture2D dirtMaskOG;
    private Texture2D dirtMask;
    public Texture2D dirtBrush;
    public Camera mainCam;

    public Material material;
    private Texture2D dirt;
    private Vector2Int lastPaintPixelPosition;
    
    public float dirtAmount;
    private float dirtAmountTotal;
    public float dirtThreshold;

    public bool isClean = false;

    private void Start()
    {
        CreateTexture();
    }

    void CreateTexture()
    {
        dirtMask = Instantiate(dirtMaskOG);
        dirtMask = new Texture2D(dirtMaskOG.width, dirtMaskOG.height);
        dirtMask.SetPixels(dirtMaskOG.GetPixels());
        dirtMask.Apply();
        
        material.SetTexture("_dirtlayer", dirtMask);
        
        dirtAmountTotal = 0f;
        for (int x = 0; x < dirtMaskOG.width; x++) {
            for (int y = 0; y < dirtMaskOG.height; y++) {
                dirtAmountTotal += dirtMaskOG.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {


            RaycastHit hitInfo;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                //uv coords where raycast hits
                Vector2 textureCoord = hitInfo.textureCoord;

                int pixelX = (int)(textureCoord.x * dirtMask.width);
                int pixelY = (int)(textureCoord.y * dirtMask.height);

                Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);
                //Debug.Log("UV: " + textureCoord + " ; Pixels: " + paintPixelPos);

                int paintPixelDistance = Mathf.Abs(paintPixelPosition.x - lastPaintPixelPosition.x) + Mathf.Abs(paintPixelPosition.y - lastPaintPixelPosition.y);
                int maxPaintDistance = 7;
                if (paintPixelDistance < maxPaintDistance) {
                    // Painting too close to last position
                    return;
                }
                lastPaintPixelPosition = paintPixelPosition;

                
                int pixelXOffset = pixelX - (dirtBrush.width / 2);
                int pixelYOffset = pixelY - (dirtBrush.height / 2);

                for (int x = 0; x < dirtBrush.width; x++)
                {
                    for (int y = 0; y < dirtBrush.height; y++)
                    {
                        Color pixelDirt = dirtBrush.GetPixel(x, y);
                        Color pixelDirtMask = dirtMask.GetPixel(pixelXOffset + x, pixelYOffset + y);

                        float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                        dirtAmount -= removedAmount;
                        
                        dirtMask.SetPixel(pixelXOffset + x, pixelYOffset + y,
                            new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                    }

                }
                
                dirtMask.Apply();

            }
            
        }

        if (dirtAmount < dirtThreshold)
        {
            isClean = true;
        }
        
    }
    
   

}
