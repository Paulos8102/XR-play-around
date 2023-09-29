using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public AudioSource finishSound;

    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        Debug.Log("Entered Finish");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            Debug.Log("Collided");
            levelCompleted = true;
            Invoke("CompleteLevel", 2f); //delay
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Quit Bich");
        Application.Quit();
    }
}
