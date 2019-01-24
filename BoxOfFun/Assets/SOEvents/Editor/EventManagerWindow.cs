using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace ScriptableObjectEvent
{
    //Display all GameEvents in the current scene - show which objects are using them
    //Include a description of what the Event does
    [ExecuteInEditMode]
    public class EventManagerWindow : EditorWindow
    {
#if UNITY_EDITOR

        //Dictionary of all objects that are using the GameEventListener
        private Dictionary<SOGameEvent, List<GameObject>> gameEventDictionary = new Dictionary<SOGameEvent, List<GameObject>>();
        public GameEventListener[] eventObjects;

        [MenuItem("Window/EventManager")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one does not exist, make one
            EditorWindow.GetWindow(typeof(EventManagerWindow));
        }

        private void OnEnable()
        {
            //If scene has changed in Editor or while running
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
            Rect r = position; //position of the window - can get the height and width from here
            float windowWidth = position.width / 4; //Width of each section

            GUIStyle centerLabelStyle = new GUIStyle();
            centerLabelStyle.alignment = TextAnchor.MiddleCenter;
            centerLabelStyle.fontStyle = FontStyle.Bold;

            GUILayout.Label("Event Manager", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox); //All the Event names
            GUILayout.Label("Event Name", centerLabelStyle, GUILayout.Width(windowWidth));
            GUILayout.Label("Description", centerLabelStyle, GUILayout.Width(windowWidth));
            GUILayout.Label("GameObject", centerLabelStyle, GUILayout.Width(windowWidth));
            GUILayout.Label("Raise Event", centerLabelStyle, GUILayout.Width(windowWidth));
            EditorGUILayout.EndHorizontal();

            //Print out a list of all the Events and each GameObject thats part of the event
            foreach (SOGameEvent key in gameEventDictionary.Keys)
            {
                //***********************Event Name***********************
                EditorGUILayout.BeginHorizontal(EditorStyles.helpBox); //All the Event names
                GUILayout.Label(key.name, GUILayout.Width(windowWidth));

                //***********************Event Description***********************
                EditorGUILayout.BeginVertical(GUILayout.MinWidth(windowWidth));
                GUI.skin.label.wordWrap = true; //Wrap the label text
                GUILayout.Label(key.eventDescription, GUILayout.Width(windowWidth));
                EditorGUILayout.EndVertical();
                //***************************************************************

                //***********************Event GameObjects***********************
                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true)); //All objects that use the Event
                foreach (GameObject value in gameEventDictionary[key])
                {
                    GUILayout.Label(value.name, GUILayout.Width(windowWidth)); //Gameobject names
                    EditorGUILayout.ObjectField(value, typeof(object), true, GUILayout.Width(windowWidth));
                }
                EditorGUILayout.EndVertical();
                //***************************************************************

                //***********************Event Raise***********************
                EditorGUILayout.BeginVertical(); //Button to trigger all the events 

                if (EditorApplication.isPlaying) //If the application is playing - draw the raise buttons
                {
                    if (GUILayout.Button("Raise Event"))
                    {
                        key.Raise(); //Raise the events
                    }
                }
                EditorGUILayout.EndVertical();
                //********************************************************

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

        /// <summary>
        /// Get all the scriptable events being used in the scene and store them in a dictionary
        /// </summary>
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

#endif
    }
}