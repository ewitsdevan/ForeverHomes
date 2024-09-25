using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public RhythmManager rhythmManager;

    public Timer timer;

    public float boundary = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if timer.currentTime = rhythm point value + or - boundary
            {
                //event -> change state to hitstate
            }
        }
        
        
    }
}
