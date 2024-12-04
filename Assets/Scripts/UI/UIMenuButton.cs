// Created by Devan Laczko, 30/09/2024
// Updated 04/12/2024

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
            
            stickersButton.GetComponent<UIFloatAnimation>().IntroAnimation();
            stickersButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
        }
        else if (settingsMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(settingsMenu, mainMenu, 1f));
            
            settingsButton.GetComponent<UIFloatAnimation>().IntroAnimation();
            settingsButton.GetComponent<Button>().interactable = true;
            
            StartCoroutine(FlipTwice(false));
        }

        StartCoroutine(QuitButton());
    }
    
    public void StickersMenu()
    {
        if (mainMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(mainMenu, stickersMenu, 0.5f));
            
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
        }
        else if (settingsMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(settingsMenu, stickersMenu, 0.5f));
            
            settingsButton.GetComponent<UIFloatAnimation>().IntroAnimation();
            settingsButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().FlipLeftPage();
        }
        
        stickersButton.GetComponent<Button>().interactable = false;
        stickersButton.GetComponent<RectTransform>().DOKill();
        stickersButton.GetComponent<UIFloatAnimation>().OutroAnimation();

        StartCoroutine(BackButton());
    }
    
    public void SettingsMenu()
    {
        if (mainMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(mainMenu, settingsMenu, 1f));
            
            StartCoroutine(FlipTwice(true));
        }
        else if (stickersMenu.activeSelf == true)
        {
            StartCoroutine(ChangeMenu(stickersMenu, settingsMenu, 0.5f));
            
            stickersButton.GetComponent<UIFloatAnimation>().IntroAnimation();
            stickersButton.GetComponent<Button>().interactable = true;
            
            bookFlipper.GetComponent<AutoFlip>().FlipRightPage();
        }
        
        settingsButton.GetComponent<Button>().interactable = false;
        settingsButton.GetComponent<RectTransform>().DOKill();
        settingsButton.GetComponent<UIFloatAnimation>().OutroAnimation();
        
        StartCoroutine(BackButton());
    }

    IEnumerator ChangeMenu(GameObject otherMenu, GameObject targetMenu, float speed)
    {
        otherMenu.GetComponent<UIFadeAnimation>().OutroAnimation();
        yield return new WaitForSeconds(speed);
        otherMenu.SetActive(false);
        
        targetMenu.SetActive(true);
        targetMenu.GetComponent<UIFadeAnimation>().IntroAnimaton();
    }

    IEnumerator BackButton()
    {
        if (backButton.GetComponent<Button>().interactable == false)
        {
            quitButton.GetComponent<Button>().interactable = false;
            quitButton.GetComponent<RectTransform>().DOKill();
            quitButton.GetComponent<UIFloatAnimation>().OutroAnimation();
            
            closeButton.GetComponent<Button>().interactable = false;
            closeButton.GetComponent<RectTransform>().DOKill();
            closeButton.GetComponent<UIFloatAnimation>().OutroAnimation();
            
            yield return new WaitForSeconds(0.5f);
            
            backButton.GetComponent<Button>().interactable = true;
            backButton.GetComponent<UIFloatAnimation>().IntroAnimation();
        }
    }

    IEnumerator QuitButton()
    {
        if (quitButton.GetComponent<Button>().interactable == false)
        {
            backButton.GetComponent<Button>().interactable = false;
            backButton.GetComponent<RectTransform>().DOKill();
            backButton.GetComponent<UIFloatAnimation>().OutroAnimation();
            
            yield return new WaitForSeconds(0.5f);
            
            quitButton.GetComponent<Button>().interactable = true;
            quitButton.GetComponent<UIFloatAnimation>().IntroAnimation();
            
            closeButton.GetComponent<Button>().interactable = true;
            closeButton.GetComponent<UIFloatAnimation>().IntroAnimation();
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
}
