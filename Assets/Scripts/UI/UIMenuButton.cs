// Created by Devan Laczko, 30/09/2024
// Updated 07/11/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour
{
    public GameObject bookFlipper;
    
    public GameObject mainMenu;
    public GameObject stickersMenu;
    public GameObject settingsMenu;

    public GameObject backButton;
    public GameObject stickersButton;
    public GameObject settingsButton;
    public GameObject quitButton;
    public GameObject closeButton;
    
    public void MainMenu()
    {
        if (stickersMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(stickersMenu, mainMenu, 0.5f));
            
            stickersButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
            stickersButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.2f;
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
        }
        else if (settingsMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(settingsMenu, mainMenu, 0.75f));
            
            settingsButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
            settingsButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.1f;
            StartCoroutine(FlipTwice(false));
        }
        else
        {
            mainMenu.SetActive(true);
            mainMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
        }

        StartCoroutine(QuitButton());
        StartCoroutine(DisableButtonWhileFlip());
    }
    
    public void StickersMenu()
    {
        if (mainMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(mainMenu, stickersMenu, 0.5f));
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.2f;
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
        }
        else if (settingsMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(settingsMenu, stickersMenu, 0.5f));
            
            settingsButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
            settingsButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.2f;
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
        }
        else
        {
            stickersMenu.SetActive(true);
            stickersMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
            stickersButton.GetComponent<UIAutoAnimation>().ExitAnimation();
        }

        StartCoroutine(BackButton());
        StartCoroutine(DisableButtonWhileFlip());
    }
    
    public void SettingsMenu()
    {
        if (mainMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(mainMenu, settingsMenu, 0.75f));
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.1f;
            StartCoroutine(FlipTwice(true));
        }
        else if (stickersMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(stickersMenu, settingsMenu, 0.5f));
            
            stickersButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
            stickersButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().PageFlipTime = 0.2f;
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
        }
        else
        {
            settingsMenu.SetActive(true);
            settingsMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
        }
        
        StartCoroutine(BackButton());
        StartCoroutine(DisableButtonWhileFlip());
    }

    IEnumerator ChangeMenu(GameObject otherMenu, GameObject targetMenu, float speed)
    {
        otherMenu.GetComponent<UIAutoAnimation>().ExitAnimation();
        yield return new WaitForSeconds(speed);
        otherMenu.SetActive(false);
        
        targetMenu.SetActive(true);
        targetMenu.GetComponent<UIAutoAnimation>().EntranceAnimation();
    }

    IEnumerator BackButton()
    {
        if (backButton.activeSelf == false)
        {
            quitButton.GetComponent<UIAutoAnimation>().ExitAnimation();
            closeButton.GetComponent<UIAutoAnimation>().ExitAnimation();
            yield return new WaitForSeconds(0.5f);
            quitButton.SetActive(false);
            closeButton.SetActive(false);
            backButton.SetActive(true);
            backButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
        }
    }

    IEnumerator QuitButton()
    {
        if (quitButton.activeSelf == false)
        {
            backButton.GetComponent<UIAutoAnimation>().ExitAnimation();
            yield return new WaitForSeconds(0.5f);
            backButton.SetActive(false);
            quitButton.SetActive(true);
            closeButton.SetActive(true);
            quitButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
            closeButton.GetComponent<UIAutoAnimation>().EntranceAnimation();
        }
    }

    IEnumerator FlipTwice(bool right)
    {
        if (right)
        {
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
            yield return new WaitForSeconds(0.5f);
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
        }
        else
        {
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
            yield return new WaitForSeconds(0.5f);
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
        }
    }

    IEnumerator DisableButtonWhileFlip()
    {
        backButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
        closeButton.GetComponent<Button>().interactable = false;
        settingsButton.GetComponent<Button>().interactable = false;
        stickersButton.GetComponent<Button>().interactable = false;
            
        yield return new WaitForSeconds(0.75f);
            
        backButton.GetComponent<Button>().interactable = true;
        quitButton.GetComponent<Button>().interactable = true;
        closeButton.GetComponent<Button>().interactable = true;
        settingsButton.GetComponent<Button>().interactable = true;
        stickersButton.GetComponent<Button>().interactable = true;
    }
}
