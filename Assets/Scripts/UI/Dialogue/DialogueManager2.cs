using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DialogueManager2 : MonoBehaviour
{
    public TextMeshProUGUI textDialogue1;
    public string[] lines;
    public float speed;
    public GameObject dialogue; 
 

    private int index;
  
    void Start()
    {
       textDialogue1.text = string.Empty;
       StartDialogue(); 
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))   
         {
            if(textDialogue1.text == lines[index]) 
            { 
                
                NextLine1();
            
            }
            else 
            {
            
                StopAllCoroutines();
                textDialogue1.text = lines[index];
                

            }
        
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Sentence());
        
    }

    IEnumerator Sentence()
    {
        //This lets us type out each line at time 

        foreach (char c in lines[index].ToCharArray())
        {

            textDialogue1.text += c;
            yield return new WaitForSeconds(speed);


        }
    }

    void NextLine1()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textDialogue1.text = string.Empty;
            StartCoroutine(Sentence());

        }
        else
        {
            //next scene
            dialogue.SetActive(false);
            SceneManager.LoadScene("Grim Book"); 
        }

    }
}

