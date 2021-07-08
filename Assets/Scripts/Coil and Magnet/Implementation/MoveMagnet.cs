using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {  
       
        transform.position = new Vector3(Mathf.Cos(Mathf.PI  * Time.time * .1f) - .138f, 1.467f, -0.155f+0.5f);
    }
}
