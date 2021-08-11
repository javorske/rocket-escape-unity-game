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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    void StartThrusting()
    {
        mainBoost.Play();
        playersRigidbody.AddRelativeForce(Vector3.up * forceSpeed * Time.deltaTime * 1000);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    void StopThrusting()
    {
        mainBoost.Stop();
        audioSource.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationSpeed, rightThruster);
    }

    void RotateRight()
    {
        ApplyRotation(-rotationSpeed, leftThruster);
    }

    void ApplyRotation(float rotaionThisFrame, ParticleSystem sideBooster)
    {
        sideBooster.Play();
        playersRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotaionThisFrame);
        playersRigidbody.freezeRotation = false;
    }
}
