using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagnetController : MonoBehaviour
{
    [SerializeField]
    GameObject magnet;

    [SerializeField]
    Slider slider;
    private float x,y,z;

    void Start()
    {
        x = magnet.transform.position.x;
        y = magnet.transform.position.y;
        z = magnet.transform.position.z;
    }
    public void SlideMagnet()
    {
        
        magnet.transform.position = new Vector3(x,y,z + slider.value);
    }
}
