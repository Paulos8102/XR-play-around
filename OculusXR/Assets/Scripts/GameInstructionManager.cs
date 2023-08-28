//Code for instructions to pop up with button

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem; //we need to listen to an action

public class GameInstructionManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2.0f;
    public GameObject instr;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( showButton.action.WasPressedThisFrame())
        {
            instr.SetActive(!instr.activeSelf);

            instr.transform.position =  head.position + new Vector3 (head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        instr.transform.LookAt (new Vector3 (head.position.x, instr.transform.forward.y, head.position.z));

        instr.transform.forward *= -1;
        //to flip the rotation of the menu
    }
}
