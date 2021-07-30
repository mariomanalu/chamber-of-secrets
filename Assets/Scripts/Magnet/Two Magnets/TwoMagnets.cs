using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoMagnets: MonoBehaviour
{
    // Two Magnets mini scene variables
    [SerializeField]
    GameObject leftPole;

    [SerializeField]
    GameObject rightPole;
    
    [SerializeField]
    Material material;
    float pointPos;

    void Update()
    {
        pointPos = (leftPole.transform.position.z + rightPole.transform.position.z) / 2;
        material.SetFloat("pointPos", pointPos);
    }
}
