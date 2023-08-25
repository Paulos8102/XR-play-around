//Code for instructions to pop up with button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //we need to listen to an action

public class GameInstructionManager : MonoBehaviour
{
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
        }
    }
}
