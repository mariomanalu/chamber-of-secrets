using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
    
    public float magnetTime;
    void Start(){
        magnetTime = 0;
    }
    // Update is called once per frame
    void Update()
    {  
        magnetTime += Time.deltaTime;
        transform.position = new Vector3(2 * Mathf.Cos(Mathf.PI  * magnetTime * .1f) - .138f, 1.467f, -0.155f+0.5f);
    }
}
