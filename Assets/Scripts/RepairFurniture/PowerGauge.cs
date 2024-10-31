// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 24/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGauge : MonoBehaviour
{
    // UI Elements
    public Image arrow;
    public Image background;
    public Image target;
    
    // Settings
    public float arrowSpeed = 1.0f;
    public float maxDistance = 1.0f;
    
    
    // Private Variables
    private Vector2 minPoint;
    private Vector2 maxPoint;
    private Vector2 minTarget;
    private Vector2 maxTarget;
    private Vector2 _nailTarget;
    private float distance;
    
    public delegate void NailHitEvent(bool success);
    public static event NailHitEvent nailHitEvent;

    void Start()
    {
        // Sets min/max points using size of bars
        minPoint.x = -background.rectTransform.rect.width / 2;
        maxPoint.x = background.rectTransform.rect.width / 2;
        minTarget.x = -target.rectTransform.rect.width / 2;
        maxTarget.x = target.rectTransform.rect.width / 2;
        
        _nailTarget = maxPoint;

    }
    void Update()
    {
        // Move arrow
        arrow.rectTransform.anchoredPosition += _nailTarget * (arrowSpeed * Time.deltaTime);
        
        // If distance between target (end of bar) is less than maxDistance, swap target (using arrow == target statement didn't work)
        distance = Mathf.Abs(_nailTarget.x - arrow.rectTransform.anchoredPosition.x);
        if (distance < maxDistance)
        {
            if (_nailTarget == maxPoint)
            {
                _nailTarget = minPoint;
            }
            else if (_nailTarget == minPoint)
            {
                _nailTarget = maxPoint;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (arrow.rectTransform.anchoredPosition.x > minTarget.x && arrow.rectTransform.anchoredPosition.x < maxTarget.x)
            {
                Debug.Log("win");
                nailHitEvent?.Invoke(success:true);
                //Destroy(gameObject);
            }
            else
            {
                Debug.Log("lose");
                nailHitEvent?.Invoke(success:false);
                //Destroy(gameObject);
            }
        }
        
    }
}
