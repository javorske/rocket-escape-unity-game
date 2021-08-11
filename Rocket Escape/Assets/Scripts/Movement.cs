using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float forceSpeed = 2f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBoost;
    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;

    Rigidbody playersRigidbody;
    AudioSource audioSource;

    void Start()
    {
        playersRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            mainBoost.Play();
            playersRigidbody.AddRelativeForce(Vector3.up * forceSpeed * Time.deltaTime * 1000);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            mainBoost.Stop();
            audioSource.Stop();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed, leftThruster);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed, rightThruster);
        }
    }

    private void ApplyRotation(float rotaionThisFrame, ParticleSystem sideBooster)
    {
        playersRigidbody.freezeRotation = true;
        sideBooster.Play();
        transform.Rotate(Vector3.forward * Time.deltaTime * rotaionThisFrame);
        playersRigidbody.freezeRotation = false;
    }
}
