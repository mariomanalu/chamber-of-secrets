using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    ComputeBuffer floatArgs, vectorArgs;

    [SerializeField]
    VectorField field;

    float[] array = {2f,2f,3f};
    Vector3[] vec_array = {new Vector3(1,0,0), new Vector3(0,0,1), new Vector3(0,1,0)};

    void Start(){
        unsafe{
        floatArgs = new ComputeBuffer(3,sizeof(float));
        vectorArgs = new ComputeBuffer(3,sizeof(Vector3));
        }

        floatArgs.SetData(array);
        vectorArgs.SetData(vec_array);

        field.floatArgsBuffer = floatArgs;
        field.vectorArgsBuffer = vectorArgs;
    }


}
