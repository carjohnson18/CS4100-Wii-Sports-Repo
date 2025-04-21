using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.tvOS;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AimContoller : MonoBehaviour
{
    public XRNode inputSource;
    public float moveSpeed = 1.0f;
    public ActionBasedContinuousTurnProvider turn;

    private bool aiming = false; 
    //private bool wasAiming = false;
    private Vector2 inputDirection;
    private InputDevice inputDevice;
    public bool resetGame = false;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        bool gripPressed = false;
        if (inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out gripPressed))
        {
            aiming = gripPressed;
        }

     
        if (aiming)
        {
            turn.enabled = false;
        }

        if (!aiming)
        {
            turn.enabled = true;
        }
        
        if (aiming)
        {
            if (inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputDirection))
            {
                Vector3 movement = new Vector3(inputDirection.x, 0.0f, inputDirection.y) * moveSpeed * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }
        }
        
    }
}

