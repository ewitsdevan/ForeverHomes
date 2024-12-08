// Created by Maddie Thynne 23/10/2024
// Updated by Devan Laczko 05/12/2024

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
    public UIFadeAnimation hitPanel;
    public UIFadeAnimation missPanel;
    
    // Settings
    public float minSize = 50;
    public float maxSize = 200;
    public float minArrowSpeed;
    public float maxArrowSpeed;
    public float maxDistance = 1.0f;
    public bool isActive;
    
    // Private Variables
    private Vector2 minPoint;
    private Vector2 maxPoint;
    private Vector2 minTarget;
    private Vector2 maxTarget;
    private Vector2 _nailTarget;
    private float distance;
    private float arrowSpeed;

    
    public delegate void NailHitEvent(bool success);
    public static event NailHitEvent nailHitEvent;

    public void Init()
    {
        // Randomises Difficulty (width, position, & speed)
        target.rectTransform.sizeDelta = new Vector2(Random.Range(minSize, maxSize), 75);
        target.rectTransform.anchoredPosition = new Vector2(Random.Range(-150, 150), -50);
        arrowSpeed = Random.Range(minArrowSpeed, maxArrowSpeed);
        
        // Sets min/max points using size of bars
        minPoint.x = -background.rectTransform.rect.width / 2;
        maxPoint.x = background.rectTransform.rect.width / 2;
        minTarget.x = (-target.rectTransform.rect.width / 2) + target.rectTransform.anchoredPosition.x;
        maxTarget.x = (target.rectTransform.rect.width / 2) + target.rectTransform.anchoredPosition.x;
        
        _nailTarget = maxPoint;

    }
    void Update()
    {
        // Move arrow
        if (isActive)
        {
            arrow.rectTransform.anchoredPosition += _nailTarget * (arrowSpeed * Time.deltaTime);
        }
        
        // If distance between target (end of bar) is less than maxDistance, swap target (using arrow == target statement didn't work)
        distance = Mathf.Abs(_nailTarget.x - arrow.rectTransform.anchoredPosition.x);
        if (distance <= maxDistance)
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
                Debug.Log("Hit!");
                nailHitEvent?.Invoke(success:true);
                //Destroy(gameObject);
                hitPanel.IntroAnimaton();
            }
            else
            {
                Debug.Log("Miss!");
                nailHitEvent?.Invoke(success:false);
                //Destroy(gameObject);
                missPanel.IntroAnimaton();
            }
        }
        
    }
}
