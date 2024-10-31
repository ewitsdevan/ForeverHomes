using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NeedleMovement : MonoBehaviour
{
    public float amp;
    public float freq;
    public NeedleControl needleControl;
    private Vector3 initPos;

    private void Start()
    {
        initPos.y = transform.position.y;
    }

    private void Update()
    {
        Vector3 position = needleControl.transform.position;
        transform.position = new Vector3(position.x, Mathf.Sin(Time.time * freq)* amp + initPos.y ,position.z);
    }
}
