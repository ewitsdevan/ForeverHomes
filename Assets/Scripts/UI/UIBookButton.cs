// Created by Devan Laczko, 26/09/2024
// Updated 30/09/2024

using System.Collections;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class UIBookButton : MonoBehaviour
{
    public GameObject imageObject;
    public Sprite icon1;
    public Sprite icon2;
    private bool toggle = false;
    public GameObject bookObject;
    public GameObject isometricCamera;
    
    public void ToggleIcon()
    {
        StartCoroutine(Animation());
        StartCoroutine(DiableButton());
    }

    private void Icon1()
    {
        imageObject.GetComponent<Image>().sprite = icon1;
    }

    private void Icon2()
    {
        imageObject.GetComponent<Image>().sprite = icon2;
    }

    IEnumerator Animation()
    {
        imageObject.GetComponent<UIAutoAnimation>().ExitAnimation();
        yield return new WaitForSeconds(0.1f);
        
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
        
        imageObject.GetComponent<UIAutoAnimation>().EntranceAnimation();
        
        // Precaution for if button shows wrong image, checks if book is shown.
        yield return new WaitForSeconds(0.25f);
        if (bookObject.activeSelf == false)
        {
            Icon1();
            toggle = false;
        }
        else if (bookObject.activeSelf == true)
        {
            Icon2();
            toggle = true;
        }
    }

    IEnumerator DiableButton()
    {
        // Temporarily disables button during animation to prevent breakage.
        gameObject.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(0.25f);
        
        gameObject.GetComponent<Button>().interactable = true;
    }
}
