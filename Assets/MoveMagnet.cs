using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {  
       
        transform.position += new Vector3(Mathf.Sin(Mathf.PI * transform.position.x * Time.time),0,0);
        
    }
}
