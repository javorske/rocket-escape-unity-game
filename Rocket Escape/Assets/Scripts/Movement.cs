using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float forceSpeed = 2f;
    [SerializeField] float rotationSpeed = 2f;
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
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotaionThisFrame)
    {
        playersRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotaionThisFrame);
        playersRigidbody.freezeRotation = false;
    }
}
