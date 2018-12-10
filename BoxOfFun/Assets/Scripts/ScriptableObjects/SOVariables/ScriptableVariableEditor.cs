using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(sFloat))]
[CanEditMultipleObjects]
public class ScriptableVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Draw the defualt inspector options
        DrawDefaultInspector();

        ScriptableVariable script = (ScriptableVariable)target;

        if (GUILayout.Button("Reset Value"))
        {
            if (EditorApplication.isPlaying)
            {
                script.ResetValue();
            }
        }
    }
}
