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
    InputActionAsset actionAsset;

    /// <summary>
    /// The "Teleport Start" action. 
    /// </summary>
    private InputAction teleportAction;

    /// <summary>
    /// The <cref>XRRayInteractor</cref> with which the user selects a teleport location. 
    /// </summary>
    public XRRayInteractor rayInteractor;

    // [SerializeField]
    // XRRayInteractor UIRayInteractor;

    [SerializeField]
    TeleportationProvider provider;

    [SerializeField]
    GameObject reticulePrefab;
    GameObject reticuleInstance;

    //public bool isUIRayActive = false;
    void Start()
    {

        string actionMapName = "XRI RightHand";
    
        teleportAction = actionAsset.FindActionMap(actionMapName).FindAction("Teleport Start");
        //rayInteractor.enabled = false;
    }

    private void Update()
    {  
        if (teleportAction.ReadValue<float>() != 0)// && !isUIRayActive)
       {
           rayInteractor.enabled = true;
           
           teleportDestination destination = CheckLocation();
            if(destination.validDestination)
            {
                // Create and file a teleportation request. 
                TeleportRequest request = new TeleportRequest()
                {
                    destinationPosition = destination.location,
                };
                provider.QueueTeleportRequest(request);
            } 
       }
       else
       {
           rayInteractor.enabled = false;
       }
       
    }

    // public void DeactivateUIRay()
    // {
    //     isUIRayActive = false;
    // }

    // public void ActivateUIRay()
    // {
    //     isUIRayActive = true;
    // }
    struct teleportDestination
    {
        public Vector3 location;
        public bool validDestination;
        public Vector3 normal;
    }

    teleportDestination CheckLocation()
    {
        teleportDestination destination = new teleportDestination();
        destination.validDestination = false;

        // Check that the interactor is enabled and pointing at something. 
        if (!(rayInteractor.enabled))
        {
            return destination;
        }
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            return destination;
        }
        // Verify that the user can teleport to the selected location. 
        TeleportationArea anchor = hit.transform.GetComponent<TeleportationArea>();
        if (anchor)
        {
            destination.validDestination = true;
            destination.location = anchor.transform.position;
            //destination.normal = anchor.transform.position.up;
        }
        else if (hit.transform.GetComponent<TeleportationArea>())
        {
            destination.validDestination = true;
            destination.location = hit.point;
            //destination.normal = hit.normal;
        }
        else
        {
            destination.validDestination = false;
            
            return destination;
        }
        return destination;
    }
}