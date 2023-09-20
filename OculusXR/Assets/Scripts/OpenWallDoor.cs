using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallDoor : MonoBehaviour
{
    public float duration = 1.0f;
    public float loweredHeight = 1.5f;

    private bool lowerDoor = false;
    private Vector3 raisedPosition;

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
            StartCoroutine(MoveDoor(raisedPosition));
        }

        lowerDoor = !lowerDoor;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while(timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
