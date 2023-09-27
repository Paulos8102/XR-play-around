using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour
{
    public InputActionAsset inputActions;

    private Canvas wristUICanvas;
    private InputAction menu;

    void Start()
    {
        wristUICanvas = GetComponent<Canvas>();
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menu.Enable();
        menu.performed += ToggleMenu;
    }

    private void OnDestroy()
    {
        menu.performed -= ToggleMenu;
    }

    private void ToggleMenu( InputAction.CallbackContext context )
    {
        wristUICanvas.enabled = !wristUICanvas.enabled;
    }
}
