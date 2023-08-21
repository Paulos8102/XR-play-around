using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;

    public InputActionProperty leftActivate;

    public InputActionProperty leftCancel;

    void Update()
    {
        leftTeleportation.SetActive(leftCancel.action.ReadValue<float>()==0 && leftActivate.action.ReadValue<float>() > 0.1f); //no teleport when grabbing objects
    }
}
