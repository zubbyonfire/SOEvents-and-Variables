using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

//Display all GameEvents in the current scene - show which objects are using them
//Include a description of what the Event does
[ExecuteInEditMode]
public class EventManagerWindow : EditorWindow
{
    //Dictionary of all objects that are using the GameEventListener
    private Dictionary<sGameEvent, GameObject> gameEventDictionary = new Dictionary<sGameEvent, GameObject>();
    public GameEventListener[] eventObjects;

    private string sceneName;
    
    [MenuItem("Window/EventManager")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one does not exist, make one
        EditorWindow.GetWindow(typeof(EventManagerWindow));
    }

    private void OnGUI()
    {
        StartWindow();

        Debug.Log(sceneName);

        GUILayout.Label("Event Manager", EditorStyles.boldLabel);

        if(GUILayout.Button("GetSceneObjects"))
        {
            GetAllEventsInScene();
        }


    }

    private void OnHierarchyChange()
    {
        if (sceneName != SceneManager.GetActiveScene().name)
        {
            GetAllEventsInScene();
        }

        GetAllEventsInScene();
    }

    private void GetAllEventsInScene()
    {
        //Clear the dictionary
        ClearDictionary();

        //Get all the eventObjects in the scene
        eventObjects = FindObjectsOfType<GameEventListener>();

        foreach(GameEventListener listener in eventObjects)
        {
            gameEventDictionary.Add(listener.Event, listener.gameObject);

            Debug.Log(listener.Event + "" +  listener.gameObject);
        }
    }

    private void ClearDictionary()
    {
        //Empty the Dictionary
        gameEventDictionary.Clear();
    }

    private void StartWindow()
    {
        //Store the sceneName
        sceneName = SceneManager.GetActiveScene().name;
    }
}
