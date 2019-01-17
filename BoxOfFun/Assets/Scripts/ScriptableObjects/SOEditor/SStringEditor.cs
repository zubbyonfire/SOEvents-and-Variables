using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(sString))]
[CanEditMultipleObjects]
public class SStringEditor : Editor
{
    //Solution: Use Reflection to compare against all components
    //Good starting point: https://answers.unity.com/questions/252903/c-reflection-get-all-public-variables-from-custom.html
    //Vid tutorial explanation: https://www.youtube.com/watch?v=85_l-bdMlSE

    //List of all gameObjects that have a component that uses this ScriptableVariable
    List<GameObject> subscribedObject = new List<GameObject>();

    public override void OnInspectorGUI()
    {
        //Draw the defualt inspector options
        DrawDefaultInspector();

        ScriptableVariable script = (ScriptableVariable)target;

        if (GUILayout.Button("Display Use"))
        {
            DisplaySubscribedObjects();
        }
    }

    private void DisplaySubscribedObjects()
    {

    }
}
