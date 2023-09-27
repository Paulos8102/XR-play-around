using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallDoor : MonoBehaviour
{
    public float duration = 1.0f;
    public float loweredHeight = 1.5f;

    private bool lowerDoor = false;
    private Vector3 raisedPosition;

    [SerializeField] private GameObject wallDoor; //to reference the automatic door close with collider
    private bool entered = false;

    [SerializeField] private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        raisedPosition = transform.position;
    }

    public void ToggleDoorOpen()
    {
        StopAllCoroutines();

        if (!lowerDoor)
        {
            Vector3 lowerPosition = raisedPosition + Vector3.down * loweredHeight;
            StartCoroutine(MoveDoor(lowerPosition));
        }
        else
        {
            //call trigger here, but how ughhhhhhh -.-
            
            StartCoroutine(MoveDoor(raisedPosition));
        }

        lowerDoor = !lowerDoor;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        doorSound.Play();

        while(timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit Detected");
    }

    //{
    //    Debug.Log("Hit Detected!");
    //    ToggleDoorOpen();
    //    //link to the lower part of the movedoor function
    //}
}
