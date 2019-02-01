﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOInt))]
    [CanEditMultipleObjects]
    public class SOIntEditor : Editor
    {
#if UNITY_EDITOR
        private int intModifyValue = 0;

        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOInt script = (SOInt)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Debugging Options", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.LabelField("Current value: " + script.value, EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            intModifyValue = EditorGUILayout.IntField("Modify current value by: ", intModifyValue);

            if (GUILayout.Button("Modify"))
            {

                script.AddValue(intModifyValue);
            }

            EditorGUILayout.EndHorizontal();

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
