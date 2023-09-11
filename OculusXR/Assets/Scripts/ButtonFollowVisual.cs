using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget; //reference of our visual button
    public Vector3 localAxis; //axis with which the button will move

    private Vector3 offset;
    private Transform pokeAttachTransform;
        
    private XRBaseInteractable interactable;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset); //To make button move in the same (defined) axis
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition); //making it back a world coordinate
        }
    }
}
