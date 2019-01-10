using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

//Get all the scriptable variables in the current scene - but also all the ones in the project folder
//Display all the variable values in the scene and who is looking at them
//Show the starting values & updating values in run mode
[ExecuteInEditMode]
public class ScriptableObjectManagerWindow : EditorWindow
{
    //Dictionary of all objects using a ScriptableObject variable

    [MenuItem("Window/ScriptableObjectManager")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one does not exist, make one
        EditorWindow.GetWindow(typeof(ScriptableObjectManagerWindow));
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnGUI()
    {
        
    }
}
