using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using UnityEditor.SceneManagement;

//Display all GameEvents in the current scene - show which objects are using them
//Include a description of what the Event does
[ExecuteInEditMode]
public class EventManagerWindow : EditorWindow
{
    //Dictionary of all objects that are using the GameEventListener
    private Dictionary<sGameEvent, List<GameObject>> gameEventDictionary = new Dictionary<sGameEvent, List<GameObject>>();
    public GameEventListener[] eventObjects;

    private string sceneName;

    [MenuItem("Window/EventManager")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one does not exist, make one
        EditorWindow.GetWindow(typeof(EventManagerWindow));
    }

    private void OnEnable()
    {
        //If scene has changed in Editor or while running
        EditorSceneManager.activeSceneChangedInEditMode += SceneUpdated;
        SceneManager.activeSceneChanged += SceneUpdated;

        EditorApplication.hierarchyChanged += HierarchyChanged;


        GetAllScriptableEventsInScene();
    }

    private void OnDisable()
    {
        EditorSceneManager.activeSceneChangedInEditMode -= SceneUpdated;
        SceneManager.activeSceneChanged -= SceneUpdated;

        EditorApplication.hierarchyChanged -= HierarchyChanged;
    }

    private void OnGUI()
    {
        StartWindow();

        GUILayout.Label("Event Manager", EditorStyles.boldLabel);

        //Print out a list of all the Events and each GameObject thats part of the event
        foreach (sGameEvent key in gameEventDictionary.Keys)
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox); //All the Event names
            GUILayout.Label(key.name); 

            EditorGUILayout.BeginVertical();
            GUILayout.Label(key.eventDescription); //Display the event description
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true)); //All objects that use the Event
            foreach (GameObject value in gameEventDictionary[key])
            {
                GUILayout.Label(value.name); //Gameobject names
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(); //Button to trigger all the events 
            if (EditorApplication.isPlaying) //If the application is playing - draw the raise buttons
            {
                if (GUILayout.Button("Raise Event"))
                {
                    key.Raise(); //Raise the events
                }
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal(); //End of the Event names
        }
    }

    /// <summary>
    /// If the scene is changed then call the GetAllScriptableEventsInScene
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void SceneUpdated(Scene current, Scene next)
    {
        GetAllScriptableEventsInScene();
    }

    /// <summary>
    /// If the Hierarchy has changed then call the GetAllScriptableEventsInScene
    /// </summary>
    private void HierarchyChanged()
    {
        GetAllScriptableEventsInScene();
    }

    private void GetAllScriptableEventsInScene()
    {
        //Clear the dictionary
        ClearDictionary();

        //Get all the eventObjects in the scene
        eventObjects = FindObjectsOfType<GameEventListener>();

        foreach (GameEventListener listener in eventObjects)
        {
            if (listener.Event != null) //Check to make sure there is an event (there won't be when the component is first added)
            {
                //Check to see if the key does not already exist in the dictionary
                if (!gameEventDictionary.ContainsKey(listener.Event))
                {
                    List<GameObject> eventObjectList = new List<GameObject>();

                    eventObjectList.Add(listener.gameObject);

                    gameEventDictionary.Add(listener.Event, eventObjectList); //Add the event and the gameObject list

                }
                else
                {
                    List<GameObject> copyList = gameEventDictionary[listener.Event]; //Get a copy of the list associated with listener event
                    copyList.Add(listener.gameObject);

                    gameEventDictionary[listener.Event] = copyList;
                }
            }
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