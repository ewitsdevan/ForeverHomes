using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ButtonIconToggle : MonoBehaviour
{
    public GameObject imageObject;
    public Sprite icon1;
    public Sprite icon2;
    private bool toggle = false;

    void Start()
    {
        
    }
    
    public void ToggleIcon()
    {
        if (toggle == false)
        {
            Icon2();
            toggle = true;
        }
        else
        {
            Icon1();
            toggle = false;
        }
    }

    private void Icon1()
    {
        imageObject.GetComponent<Image>().sprite = icon1;
    }

    private void Icon2()
    {
        imageObject.GetComponent<Image>().sprite = icon2;
    }
}
