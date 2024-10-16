using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;


public class HammerTime : MonoBehaviour
{
    public NailPosition nailPosition;
    
    public float duration;
    public float hitSpeed;

    private void Start()
    {
        
        IdleHammer();
    }

    public void IdleHammer()
    {
        transform.DORotate(new Vector3(0, 0, 35f), duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Flash);
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DORotate(new Vector3(0, 0, 90f), hitSpeed)
                .SetLoops(0)
                .SetEase(Ease.Linear)
                .onComplete = DestroyGame;
            
        }
        
    }

    void DestroyGame()
    {
        Destroy(gameObject);
    }


}
