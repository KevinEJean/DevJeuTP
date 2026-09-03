using UnityEngine;

// Script facultatif : il sert uniquement à observer le cycle de vie de Unity.
public class TestRobot : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake : le robot est créé.");
    }

    private void Start()
    {
        Debug.Log("Start : le jeu commence.");
    }

    // Évitez d'activer ce code longtemps : il écrit un message à chaque image.
    /*
    private void Update()
    {
        Debug.Log("Update : nouvelle image.");
    }
    */
}

