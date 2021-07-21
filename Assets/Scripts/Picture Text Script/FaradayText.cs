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
        int pageNumber = controller.pageNumber % 8;
        switch(pageNumber)
        {
            case 0:
                display.SetText($"Michael Faraday (1791-1867).");
                break;
            case 1:
                display.SetText($"He is often described as the world’s most brilliant experimentalist.");
                break;
            case 2:
                display.SetText($"Our current conceptions of electricity, magnetism, and force fields are all built off of Faraday’s research and ideas.");
                break;
            case 3:
                display.SetText($"Without a formal education, Faraday conceptualized force in a way that rejected the scientific dogma of the time.");
                break;
            case 4:
                display.SetText($"Many of Michel Faraday’s ideas about force and force fields appear contradictory to Newton's.");
                break;
            case 5:
                display.SetText($"For this reason, many of Faraday’s theories were initially received with immense skepticism.");
                break;
            case 6:
                display.SetText($"Faraday envisioned force fields with circular forces.");
                break;
            case 7:
                display.SetText($"Additionally, he imagined electric and magnetic force completely filling space, and not acting in straight lines.");
                break;
        }
    }
}
