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
    private Dictionary<sGameEvent, List<GameObject>> gameEventDictionary = new Dictionary<sGameEvent, List<GameObject>>();
    public GameEventListener[] eventObjects;

    private string sceneName;

    private bool eventsActive = false;
    
    [MenuItem("Window/EventManager")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one does not exist, make one
        EditorWindow.GetWindow(typeof(EventManagerWindow));

        
    }

    private void OnGUI()
    {
        StartWindow();

        //Debug.Log(sceneName);

        GUILayout.Label("Event Manager", EditorStyles.boldLabel);

        if(GUILayout.Button("GetSceneObjects"))
        {
            GetAllEventsInScene();

            eventsActive = true; //Switch on the Events active
        }

        if (eventsActive)
        {
            //Print out a list of all the Events and each GameObject thats part of the event
            foreach (sGameEvent key in gameEventDictionary.Keys)
            {
                EditorGUILayout.BeginHorizontal(EditorStyles.helpBox); //All the Event names
                GUILayout.Label(key.name);

                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true)); //All objects that use the Event
                foreach (GameObject value in gameEventDictionary[key])
                {
                    GUILayout.Label(value.name);
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
    }

    private void OnHierarchyChange()
    {
        /*if (sceneName != SceneManager.GetActiveScene().name)
        {
            GetAllEventsInScene();
        }

        GetAllEventsInScene();*/
    }

    void Update()
    {
        //GetAllEventsInScene();
    }

    private void GetAllEventsInScene()
    {
        //Clear the dictionary
        ClearDictionary();

        //Get all the eventObjects in the scene
        eventObjects = FindObjectsOfType<GameEventListener>();

        foreach(GameEventListener listener in eventObjects)
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

            //Debug.Log(listener.Event + "" +  listener.gameObject);
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

/* ##Solution for the scene change issue
[InitializeOnLoad]
public static class EditorApplicationExtended
{
    public static Action ChangeScene;

    private static string currentScene;
    private static int frameCount;
    private static float realtimeSinceStartup;
    private static int renderedFrameCount;

    static EditorApplicationExtended()
    {
        // Even if update is not the most elegant. Using hierarchyWindowChanged for CPU sake will not work in all cases, because when hierarchyWindowChanged is called, Time's values might be all higher than current values. Why? Because current values are set at the first frame. If you keep reloading the same scene, this case happens.
        EditorApplication.update += EditorApplicationExtended.DetectChangeScene;
    }

    private static void DetectChangeScene()
    {
        if (EditorApplicationExtended.currentScene != EditorApplication.currentScene ||
          // Detect change with the same scene, the real time should fill 99% of cases. Not tested but if you are able to load 2 scenes in a single frame, the time might not work.
          EditorApplicationExtended.realtimeSinceStartup > Time.realtimeSinceStartup ||
          EditorApplicationExtended.frameCount > Time.frameCount ||
          EditorApplicationExtended.renderedFrameCount > Time.renderedFrameCount)
        {
            EditorApplicationExtended.currentScene = EditorApplication.currentScene;

            if (EditorApplicationExtended.ChangeScene != null)
                EditorApplicationExtended.ChangeScene();
        }

        EditorApplicationExtended.frameCount = Time.frameCount;
        EditorApplicationExtended.realtimeSinceStartup = Time.realtimeSinceStartup;
        EditorApplicationExtended.renderedFrameCount = Time.renderedFrameCount;
    }
}
*/