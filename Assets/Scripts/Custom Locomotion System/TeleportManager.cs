using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportManager : MonoBehaviour
{
    [SerializeField]
    XRRayInteractor leftRayInteractor;

    [SerializeField]
    XRRayInteractor leftTeleportInteractor;
    public bool isInteractorActive = false;

    public void interactorSwitch()
    {
        if (isInteractorActive == false)
        {
            isInteractorActive = true;
        }
        else
        {
            isInteractorActive = false;
        }
    }
    void Update()
    {
        if (isInteractorActive)
        {
            leftTeleportInteractor.GetComponent<XRRayInteractor>().enabled = false;
            Debug.Log("SHOULD NOT BE ABLE TO TELEPORT");
        }
        else
        {
             leftTeleportInteractor.GetComponent<XRRayInteractor>().enabled = true;
        }
    }
}
