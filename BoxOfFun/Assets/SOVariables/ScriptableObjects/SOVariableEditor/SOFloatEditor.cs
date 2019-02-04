using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOFloat))]
    [CanEditMultipleObjects]
    public class SOFloatEditor : Editor
    {
#if UNITY_EDITOR

        private float floatModifyValue = 0.0f;

        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOFloat script = (SOFloat)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Debugging Options", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.LabelField("Current value: " + script.value, EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            //Display a float input field and button to add the inputted value to the current value
            floatModifyValue = EditorGUILayout.FloatField("Modify current value by: ", floatModifyValue);

            if (GUILayout.Button("Modify"))
            {
                script.AddValue(floatModifyValue);
            }

            EditorGUILayout.EndHorizontal();

            //Display button that resets the value to the starting value
            if (GUILayout.Button("Reset Value"))
            {
                if (EditorApplication.isPlaying)
                {
                    script.ResetValue();
                }
            }
            EditorGUILayout.EndVertical();

        }
#endif
    }
}
