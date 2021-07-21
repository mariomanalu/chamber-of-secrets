using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeavisideText : MonoBehaviour
{
   [SerializeField]
    TextMeshProUGUI display;

    [SerializeField]
    ControllerButton controller;
    
    void Update(){
        int pageNumber = controller.pageNumber % 10;
        switch(pageNumber)
        {
            case 0:
                display.SetText($"Oliver Heaviside (1950-1925).");
                break;
            case 1:
                display.SetText($"He simplified Maxwell’s original equations and shaped the way that they are applied.");
                break;
            case 2:
                display.SetText($"The four equations that we are familiar with today are actually Heaviside’s revisions.");
                break;
            case 3:
                display.SetText($"Maxwell arrived at twenty equations because he split six of these equations into their three Cartesian components.");
                break;
            case 4:
                display.SetText($"Heaviside further reduced the number to four.");
                break;
            case 5:
                display.SetText($"Heaviside has been deemed the last amateur scientist.");
                break;
            case 6:
                display.SetText($"He originally worked for a telegraph company, where electromagnetic theory was certainly applied, but Heaviside was never formally trained.");
                break;
            case 7:
                display.SetText($"In the nineteenth and twentieth centuries science became increasingly professionalized.");
                break;
            case 8:
                display.SetText($"Formal training, specifically in mathematics, became essential.");
                break;
            case 9:
                display.SetText($"Scientists like Faraday and Heaviside ceased to exist.");
                break;
            

        }
    }
}
