using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button1 : MonoBehaviour
{
    [SerializeField]
    VectorField field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonInteract()
    {
        field.fieldType = (VectorField.FieldType)((((int)field.fieldType) + 1) % 6);
    }
}
