using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallDoor : MonoBehaviour
{
    public float duration = 1.0f;
    public float loweredHeight = 1.5f;

    public bool lowerDoor = false;
    private Vector3 raisedPosition;

    public bool entered = false;

    [SerializeField] private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        raisedPosition = transform.position;
    }

    public void ToggleDoorOpen()
    {
        StopAllCoroutines();

        if (!lowerDoor)   //to lower (open the gate)
        {
            Vector3 lowerPosition = raisedPosition + Vector3.down * loweredHeight;
            StartCoroutine(MoveDoor(lowerPosition));
            Debug.Log("door opened");
        }
        else
        {
            StartCoroutine(MoveDoor(raisedPosition));
            Debug.Log("door closed");
        }
        
        lowerDoor = !lowerDoor; //switchig the bool
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Hit Detected");
            entered = true;

            StartCoroutine(MoveDoor(raisedPosition));
            Debug.Log("door closed");

            lowerDoor = false;
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;  //to keep a check on the time taken since coroutine started
        Vector3 startPosition = transform.position;

        doorSound.Play();

        Debug.Log("Moving Door");

        while(timeElapsed < duration) //as long as the door closes, as t in Lerp in between [0,1]
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);   // t is a ratio, becoz for smooth movement of door incrementally 
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
