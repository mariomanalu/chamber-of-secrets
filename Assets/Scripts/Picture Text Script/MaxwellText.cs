using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MaxwellText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display;

    [SerializeField]
    ControllerButton controller;
    
    void Update(){
        int pageNumber = controller.pageNumber % 5;
        switch(pageNumber)
        {
            case 0:
                display.SetText($"James Clerk Maxwell (1831-1879).");
                break;
            case 1:
                display.SetText($"He was a highly educated mathematician/ physicist..");
                break;
            case 2:
                display.SetText($"He was persuaded by Faraday’s ideas and careful experimentation and sought to derive equations which would describe Faraday’s lines of force.");
                break;
            case 3:
                display.SetText($"Without a formal education, Faraday was able to conceptualize force in a way that rejected the scientific dogma of the time.");
                break;
            case 4:
                display.SetText($"MORE TEXT TO COME");
                break;
        }
    }
}
