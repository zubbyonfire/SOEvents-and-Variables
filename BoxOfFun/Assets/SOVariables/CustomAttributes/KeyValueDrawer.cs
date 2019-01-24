using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectVariable
{
    [CustomPropertyDrawer(typeof(KeyValueAttribute))]
    public class KeyValueDrawer : PropertyDrawer
    {
#if UNITY_EDITOR
        /*public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            string valueStr;

            switch (property.ToString())
            {
                case "SOString":
                    valueStr = property.stringValue.ToString();
                    break;
                case "SOFloat":
                    valueStr = property.floatValue.ToString("0.000000");
                    break;
                case "SOInt":
                    valueStr = property.intValue.ToString();
                    break;
                case "SOBool":
                    valueStr = property.boolValue.ToString();
                    break;
                case "SOVector3":
                    valueStr = property.vector3Value.ToString();
                    break;
                case "SOGameObject":
                    //valueStr = property..ToString();
                    break;

            }
        }*/
#endif
    }
}
