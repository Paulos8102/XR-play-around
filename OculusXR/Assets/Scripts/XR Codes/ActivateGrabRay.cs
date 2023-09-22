using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//This script is to disable ray to be cast when already holding onto an object

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rightGrabRay;

    //reference to these rays
    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;

    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0); //Ray activates only while holding a particular no. of objects
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
