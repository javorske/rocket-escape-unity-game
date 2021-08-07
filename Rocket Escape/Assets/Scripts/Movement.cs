using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float forceSpeed = 2f;
    Rigidbody playersRigidbody;
    void Start()
    {
        playersRigidbody = GetComponent<Rigidbody>();
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
            playersRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * forceSpeed * 1000);
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
