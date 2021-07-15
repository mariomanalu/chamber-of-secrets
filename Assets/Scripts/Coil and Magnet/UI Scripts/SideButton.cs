using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideButton : MonoBehaviour
{
    [SerializeField]
    VectorField field;
    public void ButtonNext()
    {
        field.fieldType = (VectorField.FieldType)((((int)field.fieldType) + 1) % 6);
    }

    public void ButtonPrev()
    {
        field.fieldType = (VectorField.FieldType)((6 + ((int)field.fieldType) - 1) % 6);
    }
}
