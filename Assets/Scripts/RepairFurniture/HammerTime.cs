using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;


public class HammerTime : MonoBehaviour
{
    public AnimationCurve curve;
    
    public NailPosition nailPosition;
    
    public float duration;
    public float hitSpeed;

    TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore;

    private void Start()
    {
        
        IdleHammer();
    }

    public void IdleHammer()
    {
        tweenerCore = transform.DORotate(new Vector3(0, 0, 35f), duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Flash);
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tweenerCore.Kill();
            
            transform.DORotate(new Vector3(0, 0, 90f), hitSpeed)
                .SetLoops(0)
                .SetEase(curve)
                .onComplete = HitNail;
            
        }
        
    }

    void HitNail()
    {
        Debug.Log("HitNail");
        Destroy(gameObject);
    }


}
