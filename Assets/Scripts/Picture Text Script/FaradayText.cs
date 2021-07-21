using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FaradayText : MonoBehaviour
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
                display.SetText($"Michael Faraday (1791-1867).");
                break;
            case 1:
                display.SetText($"He is often described as the world’s most brilliant experimentalist.");
                break;
            case 2:
                display.SetText($"Our current conceptions of electricity, magnetism, and force fields are all built off of Faraday’s research and ideas");
                break;
            case 3:
                display.SetText($"Without a formal education, Faraday was able to conceptualize force in a way that rejected the scientific dogma of the time.");
                break;
            case 4:
                display.SetText($"His ideas completely shifted the way that we view force.  .");
                break;
        }
    }
}
