using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(sGameEvent))]
[CanEditMultipleObjects]
public class ScriptableGameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Draw the defualt inspector options
        DrawDefaultInspector();

        sGameEvent script = (sGameEvent)target;

        //Draw button
        if (GUILayout.Button("Raise Event"))
        {
            //If the application is playing - raise/trigger the event
            if (EditorApplication.isPlaying)
            {
                script.Raise();
            }
        }
    }
}
