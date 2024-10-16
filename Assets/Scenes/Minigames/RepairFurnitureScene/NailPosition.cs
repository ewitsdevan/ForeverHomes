using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailPosition : MonoBehaviour
{
    public PlayerInput playerInput;

    public Vector3 nailPos;
    public GameObject nailObj;
    public GameObject copy;

    private void OnEnable()
    {
        playerInput.playerAddNailEvent += addNail;
    }

    private void addNail()
    {
        //Only allow player to play one nail
        nailPos = playerInput.point;
        playerInput.enabled = false;

        copy = Instantiate(nailObj, nailPos, Quaternion.identity);
        
        
        //Enable hammer and power gauge
        nailObj.transform.GetChild(0).gameObject.SetActive(true);
        nailObj.transform.GetChild(1).gameObject.SetActive(true);
        

    }

    public void SuccessfulHit()
    {
        //move nail down into end position

        StartCoroutine(destroyPowerGauge());
    }

    public void FailedHit()
    {
        //change nail prefab 
        StartCoroutine(destroyPowerGauge());
    }

    IEnumerator destroyPowerGauge()
    {
        Destroy(copy.transform.GetChild(0).gameObject);
        yield return null;
    }
    
    private void OnDisable()
    {
        playerInput.playerAddNailEvent -= addNail;
    }
}
