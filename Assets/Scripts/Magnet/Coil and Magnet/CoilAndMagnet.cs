using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilAndMagnet : MonoBehaviour
{
    // Coil and Magnet mini scene variables

    [SerializeField]
    GameObject magnet;

    [SerializeField]
    Material material;

    float topBorder, bottomBorder;

    void Update()
    {

        topBorder = magnet.transform.position.y;
        bottomBorder = magnet.transform.position.y;

        material.SetFloat("topBorder", topBorder);
        material.SetFloat("bottomBorder", bottomBorder);
    }
}
