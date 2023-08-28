using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;

    public InputActionProperty leftActivate;

    public InputActionProperty leftCancel;

    public XRRayInteractor leftRay;

    void Update()
    {
        //leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);

        leftTeleportation.SetActive( leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);
        //no teleport when grabbing objects

        //bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid); //Random arguments

        //leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);
    }
}
