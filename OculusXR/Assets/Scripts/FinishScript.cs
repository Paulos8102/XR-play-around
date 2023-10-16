using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public AudioSource finishSound;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered Finish");
        finishSound.Play();

        Debug.Log("Collided");

        Invoke("CompleteLevel", 2f); //delay
    }

    private void CompleteLevel()
    {
        Debug.Log("Quit Bich");
        Application.Quit();
    }
}
