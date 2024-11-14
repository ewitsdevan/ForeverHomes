// Created by Devan Laczko 14/11/2024

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public UIAutoAnimation textBox;
    public GameObject background;
    public GameObject grimPose1;
    public GameObject grimPose2;
    public UILoading loadingScreen;
    
    [Serializable] public struct Dialogue { public string[] lines; }
    [SerializeField] public Dialogue[] dialogues;
    public float speed;

    private int linesIndex;
    private int dialoguesIndex;
    
    
    
    void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue(); 
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
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
    }

    public void StartDialogue()
    {
        linesIndex = 0;
        StartCoroutine(Sentence());
        
    }

    IEnumerator Sentence()
    {
        
        //This lets us type out each line at time 
        foreach (char c in dialogues[dialoguesIndex].lines[linesIndex].ToCharArray())
        {

            textDialogue.text += c;
            yield return new WaitForSeconds(speed);


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
        else
        {
            // Next Dialogue Act
            if (dialoguesIndex == 0)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                
                background.SetActive(true);
                background.GetComponent<UIAutoAnimation>().EntranceAnimation();
                grimPose1.SetActive(true);
                grimPose1.GetComponent<UIAutoAnimation>().EntranceAnimation();
                StartDialogue();
            }
            else if (dialoguesIndex == 1)
            {
                dialoguesIndex++;
                textDialogue.text = string.Empty;
                grimPose1.GetComponent<UIAutoAnimation>().ExitAnimation();
                grimPose2.SetActive(true);
                grimPose2.GetComponent<UIAutoAnimation>().EntranceAnimation();
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
}
