using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip crashClip;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning;
    bool collisionDisable = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        CheckCollider(collision);
    }

    void CheckCollider(Collision collision)
    {
        if (isTransitioning || collisionDisable) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartFinishSequence()
    {
        Sequence(successParticles, nameof(LoadNextLevel), successClip);
    }

    void StartCrashSequence()
    {
        Sequence(crashParticles, nameof(ReloadLevel), crashClip);
    }

    void Sequence(ParticleSystem successOrCrash, string LoadingMethodName, AudioClip clipToPlay)
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(clipToPlay);
        GetComponent<Movement>().enabled = false;
        successOrCrash.Play();
        Invoke(LoadingMethodName, clipToPlay.length + 0.5f);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
