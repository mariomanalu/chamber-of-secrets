using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagnetController : MonoBehaviour
{
    [SerializeField]
    GameObject leftMagnet;
    [SerializeField]
    GameObject rightMagnet;

    [SerializeField]
    Slider leftSlider;

    [SerializeField]
    Slider rightSlider;
    private float leftX,leftY,leftZ;
    private float rightX,rightY,rightZ;

    void Start()
    {
        leftX = leftMagnet.transform.position.x;
        leftY = leftMagnet.transform.position.y;
        leftZ = leftMagnet.transform.position.z;

        rightX = rightMagnet.transform.position.x;
        rightY = rightMagnet.transform.position.y;
        rightZ = rightMagnet.transform.position.z;
    }
    public void SlideLeftMagnet()
    {
        
        leftMagnet.transform.position = new Vector3(leftX, leftY, leftZ + leftSlider.value);
    }

    public void SlideRightMagnet()
    {
        
        rightMagnet.transform.position = new Vector3(rightX, rightY, rightZ + rightSlider.value);
    }
}
