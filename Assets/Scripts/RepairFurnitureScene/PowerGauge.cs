using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGauge : MonoBehaviour
{
    public GameObject minPoint;
    public GameObject maxPoint;

    public GameObject minGreen;
    public GameObject maxGreen;
    
    public float speed;
    private Vector3 nailTarget;
    
    public delegate void NailHitEvent(bool success);
    public static event NailHitEvent nailHitEvent;

    void Start()
    {
        nailTarget = maxPoint.transform.position;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nailTarget, speed * Time.deltaTime);

        //move arrow above gauge bar
        if (transform.position == nailTarget)
        {
            if (nailTarget == maxPoint.transform.position)
            {
                nailTarget = minPoint.transform.position;
            }
            else if (nailTarget == minPoint.transform.position)
            {
                nailTarget = maxPoint.transform.position;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x > minGreen.transform.position.x && transform.position.x < maxGreen.transform.position.x)
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
