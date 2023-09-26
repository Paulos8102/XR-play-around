using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget; //reference of our visual button
    public Vector3 localAxis; //axis with which the button will move
    public float resetSpeed = 5.0f;
    public float followAngleThreshold = 45.0f;

    private bool freeze = false;

    private Vector3 initialLocalPos;

    private Vector3 offset;
    private Transform pokeAttachTransform;
        
    private XRBaseInteractable interactable;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        initialLocalPos = visualTarget.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            freeze = false;
            
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis)); //to not allow downward uplift

            if(pokeAngle < followAngleThreshold)
            {
                isFollowing = false;
                freeze = true;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover) //funtion to not follow after poke interaction 
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
             
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze) //if fixed it'll never come down to update the position values
            return;

        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset); //To make button move in the same (defined) axis
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition); //making it back a world coordinate
        }

        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed); //set back to initial position if button no fully pressed
        }
    }
}
