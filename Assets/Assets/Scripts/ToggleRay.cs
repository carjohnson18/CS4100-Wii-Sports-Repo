using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleRay : MonoBehaviour{

    public XRRayInteractor rayInteractor;
    public InputActionProperty gripAction;
    private void OnEnable()
    {
        gripAction.action.Enable();
    }
    private void OnDisable()
    {
        gripAction.action.Disable();
    }
    void Update()
    {
        float gripValue = gripAction.action.ReadValue<float>();
        rayInteractor.gameObject.SetActive(gripValue > 0.1f);
    }
}
