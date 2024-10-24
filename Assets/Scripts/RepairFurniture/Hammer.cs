using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Ease hammerEase;
    public float speed;
    
    public void Hit()
    {
        gameObject.transform.DOLocalRotate(new Vector3(90, 0, 0), speed).SetEase(hammerEase);
        
    }
}
