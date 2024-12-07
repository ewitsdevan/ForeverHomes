// Created by Devan Laczko 14/11/2024
// Updated 04/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class UIDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public GameObject background;
    public GameObject grimPose1;
    public GameObject grimPose2;
    public UILoading loadingScreen;
    public UIFloatAnimation controls;
    
    [Serializable] public struct Dialogue { public string[] lines; }
    [SerializeField] public Dialogue[] dialogues;
    public float speed;
    public bool isInGame;

    private int linesIndex;
    private int dialoguesIndex;
    private bool once;

    public AudioSource buttonSFX;
    public AudioSource dialogueSFX;
    public float dialogueMinPitch;
    public float dialogueMaxPitch;
    
    void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue(); 
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContinueButton();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !once)
        {
            once = true;
            SkipCutscene();
        }
    }

    public void ContinueButton()
    {
        buttonSFX.Play();
            
        if(textDialogue.text == dialogues[dialoguesIndex].lines[linesIndex]) 
        { 
                
            NextLine();
            
        }
        else 
        {
            
            StopAllCoroutines();
            textDialogue.text = dialogues[dialoguesIndex].lines[linesIndex];
        }
    }

    public void StartDialogue()
    {
        linesIndex = 0;
        StartCoroutine(Sentence());
        
    }

    IEnumerator Sentence()
    {
        if (dialogues[dialoguesIndex].lines[linesIndex].Contains("<i>"))
        {
            textDialogue.text = dialogues[dialoguesIndex].lines[linesIndex];
        }
        else
        {
            //This lets us type out each line at time 
            foreach (char c in dialogues[dialoguesIndex].lines[linesIndex].ToCharArray())
            {
                textDialogue.text += c;
                dialogueSFX.pitch = Random.Range(dialogueMinPitch, dialogueMaxPitch);
                dialogueSFX.Play();
                yield return new WaitForSeconds(speed);
            }
        }
    }

    void NextLine()
    {
        if (linesIndex < dialogues[dialoguesIndex].lines.Length - 1)
        {
            linesIndex++;
            textDialogue.text = string.Empty;
            StartCoroutine(Sentence());

        }
        else if (!isInGame)
        {
            // Next Dialogue Act
            if (dialoguesIndex == 0)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                
                background.SetActive(true);
                background.GetComponent<UIFadeAnimation>().IntroAnimaton();
                grimPose1.SetActive(true);
                grimPose1.GetComponent<UIFadeAnimation>().IntroAnimaton();
                StartDialogue();
            }
            else if (dialoguesIndex == 1)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                grimPose1.GetComponent<UIFadeAnimation>().OutroAnimation();
                grimPose2.SetActive(true);
                grimPose2.GetComponent<UIFadeAnimation>().IntroAnimaton();
                StartDialogue();
                
            }
            else if (dialoguesIndex == 2)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                StartDialogue();
            }
            else if (dialoguesIndex == 3)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                loadingScreen.gameObject.SetActive(true);
                loadingScreen.LoadGameScene();
            }
        }
    }

    public void SkipCutscene()
    {
        controls.OutroAnimation();
        loadingScreen.gameObject.SetActive(true);
        loadingScreen.LoadGameScene();
    }
}
