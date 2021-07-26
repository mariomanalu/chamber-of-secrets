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



    void Start()
    {

        string actionMapName = "XRI RightHand";
    
        teleportAction = actionAsset.FindActionMap(actionMapName).FindAction("Teleport Start");
    }

    private void Update()
    {   
       if (teleportAction.ReadValue<float>() != 0)
       {
           rayInteractor.enabled = true;
       }
       else{
           rayInteractor.enabled = false;
       }

    }
}