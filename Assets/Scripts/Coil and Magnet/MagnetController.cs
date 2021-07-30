using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagnetController : MonoBehaviour
{
    [SerializeField]
    GameObject leftMagnet;

    [SerializeField]
    Slider leftSlider;
    private float leftX,leftY,leftZ;

    void Start()
    {
        leftX = leftMagnet.transform.position.x;
        leftY = leftMagnet.transform.position.y;
        leftZ = leftMagnet.transform.position.z;
    }
    public void SlideLeftMagnet()
    {
        
        leftMagnet.transform.position = new Vector3(leftX, leftY, leftZ + leftSlider.value);
    }
}
