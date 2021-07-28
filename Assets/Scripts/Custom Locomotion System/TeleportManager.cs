using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// This is an alternative to the default teleportation system. It initializes, enabling the ray interactor, 
/// when the user triggers the "Teleport Start" action, and teleports the user (if the position is valid) when 
/// the action is ended. 
/// </summary>
public class TeleportManager : MonoBehaviour
{
    /// <summary>
    /// The input action asset storing the "Teleport Start" action.
    /// </summary>
    [SerializeField]
    private InputActionAsset actionAsset;

    [SerializeField]
    private TeleportationProvider provider;
    private InputAction _thumbstick;

    [SerializeField]
    private XRRayInteractor rayInteractor;

    private bool _isActive;
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Start");
        activate.Enable();
        activate.performed += OnTeleportActivate;
        
        var cancel = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;
        
        _thumbstick = actionAsset.FindActionMap("XRI RightHand").FindAction("Move");
        _thumbstick.Enable();
    }

    void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if(_thumbstick.triggered)
        {
            return;
        }

        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            //rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        provider.QueueTeleportRequest(request);
        //rayInteractor.enabled = false;
        //_isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        Debug.Log("IN OnTeleportActive");
        rayInteractor.enabled = true;
        Debug.Log("Ray Interactor is enabled");
        _isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        Debug.Log("IN OnTeleportCancel");
        rayInteractor.enabled = false;
        _isActive = false;
    }
}