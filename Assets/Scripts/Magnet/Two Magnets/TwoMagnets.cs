using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TwoMagnets: MonoBehaviour
{
    // Two Magnets mini scene variables

    // The poles are needed to determine the invisible plane that divides the dynamic magnet into two equal cubes
    [SerializeField]
    GameObject northPoleDynamicMagnet;

    [SerializeField]
    GameObject southPoleDynamicMagnet;

    // In the update, we will compute the electrostatic force
    // Thus, we assume that the south pole / right pole of the dynamic magnet is one charge
    // and the north pole / left pole of the static magnet to be the other charge in the equation
    // We reference the north pole of the static magnet in the serialized field below
    [SerializeField]
    GameObject northPoleStaticMagnet;
    
    [SerializeField]
    Material material;
    float pointPos;

    [SerializeField]
    TextMeshProUGUI display;

    

    // We know that throughout the game and across all the scripts that references magnets
    // the magnitude of the charges are the same namely +3 for the negative charge and -3 for the positive charge.
    
    // DISCLAIMER
    // Ideally, we would just reference these charges in the Magnetic.cs file. But, I am running out of time at the time of writing this.
    // Thus, I will create variables that represent these charges.
    // The impact of this is that
    // If the charges need to be changed for some reasons, the visualization of the field will no longer be accurate.

    float positiveCharge = 3;
    float negativeCharge = -3;

    // Coulomb's constant
    float k = 9 * 10^9;

    void Update()
    {
        // Set the shader to clip the vectors that are behind the magnet
        pointPos = (northPoleDynamicMagnet.transform.position.z + southPoleDynamicMagnet.transform.position.z) / 2;
        material.SetFloat("pointPos", pointPos);

        
        // Computing the electrostatic force equation
        float distanceSquared = Mathf.Pow(Mathf.Abs(southPoleDynamicMagnet.transform.position.z - northPoleStaticMagnet.transform.position.z),2);
        float force = k * positiveCharge * negativeCharge / distanceSquared;
        Debug.Log(force);
        display.SetText("The electrostatic force between the two poles is " + force);
    }
}
