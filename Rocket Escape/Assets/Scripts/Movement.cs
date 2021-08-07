using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("pressed space");
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("preseed left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("preseed right");
        }
    }
}
