using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Code found at: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
//By Lev-Lukomskyi
//Used to make variables in the inspector read-only

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string valueStr;

        switch (property.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = property.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = property.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = property.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = property.stringValue;
                break;
            default:
                valueStr = "(not supported)";
                break;
        }

        
        EditorGUI.DrawRect(new Rect(position.x -1f, position.y -1f, position.width + 2f, position.height + 2f), Color.black);
        EditorGUI.DrawRect(new Rect(position.x + .5f, position.y - .5f, position.width - 1f, position.height), Color.white);

        EditorGUI.LabelField(position, label.text, valueStr);
    }
}
