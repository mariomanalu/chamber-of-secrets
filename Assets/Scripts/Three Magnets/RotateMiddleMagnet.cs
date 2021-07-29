using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMiddleMagnet : MonoBehaviour
{
    [SerializeField]
    GameObject magnet;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        Quaternion target = Quaternion.Euler(0, 0, 60.0f);
        magnet.transform.rotation = Quaternion.Slerp(magnet.transform.rotation, target, Time.deltaTime * 5.0f);   
    }
}
