using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMagnet : MonoBehaviour
{
    
    public float sliderValue;
    
    public bool isPaused;
    void Start(){
        sliderValue = 1.862f;
        isPaused = true;
    }
    // Update is called once per frame
    void Update()
    {  
        // If NOT paused
        if (!isPaused)
        {
            transform.position = new Vector3(2 * Mathf.Cos(Mathf.PI  * sliderValue * .1f) - .138f, 1.467f, 0.345f);
            //Debug.Log("SliderValue in MoveMagnet = " + sliderValue);
        }
    }
}
