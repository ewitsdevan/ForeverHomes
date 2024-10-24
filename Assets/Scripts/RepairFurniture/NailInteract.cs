using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class NailInteract : MonoBehaviour
{
    public Hammer hammer;
    public GameObject powerGauge;
    public GameObject hammerPrefab;
    public GameObject hammerPos;

    public GameObject IdleNail;
    public GameObject SuccessNail;
    public GameObject FailNail;

    public Collider nailCollider;
    public ParticleSystem prompt;

    public bool inputEnabled;
    private bool interacted;
    public float speed;

    
        
    
    private void OnEnable()
    {
        PowerGauge.nailHitEvent += NailHit;
        inputEnabled = true;

    }

    private void OnMouseDown()
    {
        Interact();
        
    }


    void Interact()
    {
        interacted = true;
        prompt.Stop();
        inputEnabled = false;
        
        IdleNail.SetActive(true);
        powerGauge.SetActive(true);

        //todo add hammer 
        //hammerPrefab.transform.position = hammerPos.transform.position;
        

    }
    
            
    private void NailHit(bool success)
    {
        if (interacted)
        {
            //todo add hammer 
            //hammerPrefab.SetActive(true);
            IdleNail.SetActive(false);
            powerGauge.SetActive(false);
            
            //todo add hammer 
            //hammer.Hit();
            

            if (success)
            {
                SuccessNail.SetActive(true);
                //set success nail active
                //play success particle
                
                //todo add hammer 
                //StartCoroutine(DeleteHammer());

            }

            if (success == false)
            {
                FailNail.SetActive(true);
                //play fail particle
            }
            
            interacted = false;
            nailCollider.enabled = false;
        }

        

    }

    IEnumerator DeleteHammer()
    {
        yield return new WaitForSeconds(1);
        hammerPrefab.SetActive(false);
    }

    private void OnDisable()
    {
        PowerGauge.nailHitEvent += NailHit;
        inputEnabled = false;
    }
}
