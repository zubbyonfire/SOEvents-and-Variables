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

    int tabSelected = 0;

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
        
        tabSelected = GUILayout.Toolbar(tabSelected, new string[] { "Scene", "Project", "Game Running" });
        switch (tabSelected)
        {
            case 0: //All scriptable objects in the scene
                GUILayout.Label("All the scriptable variables being used in the current scene", EditorStyles.helpBox);
                break;
            case 1: //All scriptable objects in the project
                GUILayout.Label("All the scriptable variables in the project folder", EditorStyles.helpBox);
                break;
            case 2: //Tracks scriptable objects in the scene - so can see their values - from start to now
                GUILayout.Label("All the scriptable variables being used in the current scene and their starting + current values", EditorStyles.helpBox);
                break;
        }

    }
}
