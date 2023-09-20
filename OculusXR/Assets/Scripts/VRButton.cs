using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public float deadTime = 1.0f;   //time of button inactivity after release
    private bool _deadTimeActivate = false; //used to lock button down

    public UnityEvent onPressed, onReleased;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActivate)
        {
            onPressed?.Invoke();
            Debug.Log("Button is pressed!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActivate)
        {
            onReleased?.Invoke();
            Debug.Log("Button is released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    //locks the button as inactive for a while
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActivate = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActivate = false;
    }
}
