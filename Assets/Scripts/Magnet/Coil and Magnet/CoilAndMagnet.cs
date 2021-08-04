using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CoilAndMagnet : MonoBehaviour
{
    // Coil and Magnet mini scene variables

    [SerializeField]
    GameObject magnet;

    [SerializeField]
    Material material;

    [SerializeField]
    TextMeshProUGUI display;

    [SerializeField]
    ControllerButton controller;

    float topBorder, bottomBorder;

    void Update()
    {

        topBorder = magnet.transform.position.y;
        bottomBorder = magnet.transform.position.y;

        material.SetFloat("topBorder", topBorder);
        material.SetFloat("bottomBorder", bottomBorder);

        int pageNumber = controller.pageNumber % 9;
        if (pageNumber < 0)
        {
            pageNumber += 9;
        }
        switch(pageNumber)
        {
            case 0:
                display.SetText($"Michael Faraday's Magnetic Field Induction Experiment.");
                break;
            case 1:
                display.SetText($"This experience is grounded on Faraday’s coil and magnet experimentin  1831.");
                break;
            case 2:
                display.SetText($" He  did  not  only  discover  electromagnetic  induction  but  also  understand what  makes  electromagnetic  induction  possible.");
                break;
            case 3:
                display.SetText($"The explanation behind electromagnetic induction is summarized by Faraday’s Law.");
                break;
            case 4:
                display.SetText($"Faraday’s Law states that a changing magnetic field createsan electric field.");
                break;
            case 5:
                display.SetText($"He  did  not  only  discover  electromagnetic  induction  but  also  understand what  makes  electromagnetic  induction  possible.");
                break;
            case 6:
                display.SetText($"The key idea illustrated in this experience isas follows.");
                break;
            case 7:
                display.SetText($"When the magnet moves, there is a change in the magnetic field.");
                break;
            case 8:
                display.SetText($"The change in the magnetic field generates an electric field and results in a flow of current that turns the light bulb on.");
                break;
        }
    }
}
