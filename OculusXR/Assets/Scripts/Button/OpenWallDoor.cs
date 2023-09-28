using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallDoor : MonoBehaviour
{
    public float duration = 1.0f;
    public float loweredHeight = 1.5f;

    public bool lowerDoor = false;
    private Vector3 raisedPosition;

    [SerializeField] private GameObject wallDoor; //to reference the automatic door close with collider
    public bool entered = false;

    [SerializeField] private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        raisedPosition = transform.position;
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hit Detected");
        entered = true;
        
        ToggleDoorOpen();
    }

    public void ToggleDoorOpen()
    {
        StopAllCoroutines();

        if (entered == true && lowerDoor == false)
        {
            StartCoroutine(MoveDoor(raisedPosition));
            Debug.Log("guy entered + door closed");
        }

        if (!lowerDoor)   //to lower (open the gate)
        {
            Vector3 lowerPosition = raisedPosition + Vector3.down * loweredHeight;
            StartCoroutine(MoveDoor(lowerPosition));
            Debug.Log("door opened");
        }
        else
        {
            //call trigger here, but how ughhhhhhh -.-
            
            StartCoroutine(MoveDoor(raisedPosition));
            Debug.Log("door closed");
        }
        
        //if(entered != true)
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

    //{
    //    Debug.Log("Hit Detected!");
    //    ToggleDoorOpen();
    //    //link to the lower part of the movedoor function
    //}
}
