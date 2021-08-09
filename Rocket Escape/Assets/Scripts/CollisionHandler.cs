﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("It's just a freindly object");
                break;
            case "Finish":
                Debug.Log("Touched the landing pad");
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }
}
