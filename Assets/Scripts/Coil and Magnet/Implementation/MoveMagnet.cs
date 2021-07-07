using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {  
       
        transform.position = new Vector3(Mathf.Cos(Mathf.PI  * Time.time * .1f) - .138f, 1.467f, -0.155f+0.5f);
        //Debug.Log("The time is" + Time.time);
        //Vector3 dummy = new Vector3(11 - 1, 11 - 1, 11 - 1) * 0.5f * 0.1f;

        //transform.position = new Vector3(Mathf.Cos(Mathf.PI  * Time.time),0,0) + dummy;
        
    }
}
