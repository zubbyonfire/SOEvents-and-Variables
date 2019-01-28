using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

namespace ScriptableObjectVariable
{
    [ExecuteInEditMode]
    public class ScriptableVariableTrackerWindow : EditorWindow
    {
        private List<ScriptableVariable> scriptableVariableList;

        private Rect mainPanel;
        private Vector2 mainPanelScroll;

        private int numberOfSelectionPanels;

        ScriptableVariable currentVar;
        ScriptableVariable selectedVar;

        [MenuItem("Window/ScriptableVariableTracker")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one does not exist, make one
            EditorWindow.GetWindow(typeof(ScriptableVariableTrackerWindow));
        }

        private void OnEnable()
        {
            this.scriptableVariableList = new List<ScriptableVariable>();

            numberOfSelectionPanels = 0;
        }

        private void OnDisable()
        {
            
        }

        private void OnGUI()
        {
            //Add a scriptable object to the list
            AddScriptableVariable();

            string commandName = Event.current.commandName;

            if (commandName == "ObjectSelectorUpdated")
            {
                currentVar = (ScriptableVariable)EditorGUIUtility.GetObjectPickerObject();

                Repaint();
            }
            else if (commandName == "ObjectSelectorClosed")
            {
                selectedVar = (ScriptableVariable)EditorGUIUtility.GetObjectPickerObject();

                if (!scriptableVariableList.Contains(selectedVar) && selectedVar != null)
                {
                    scriptableVariableList.Add(selectedVar);
                }
            }

            foreach (ScriptableVariable soVar in scriptableVariableList)
            {
                EditorGUILayout.ObjectField(soVar, typeof(ScriptableVariable), true);

                if (GUILayout.Button("Remove Variable"))
                {
                    //Error here
                    List<ScriptableVariable> tempList = scriptableVariableList;
                    tempList.Remove(soVar);
                    scriptableVariableList = tempList;
                    Repaint();
                }
            }
        }

        private void DrawMainArea()
        {
            mainPanel = new Rect(0, 0, position.width, position.height);

            GUILayout.BeginArea(mainPanel);
            mainPanelScroll = GUILayout.BeginScrollView(mainPanelScroll);

            //Draw panels
            if (numberOfSelectionPanels != 0)
            {
                GUILayout.BeginHorizontal();
                //Draw a box and foreach selectionPanel
                GUILayout.EndHorizontal();
            }


            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        private void AddScriptableVariable()
        {
            if (GUILayout.Button("Add Scriptable Variable"))
            {
                int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<ScriptableVariable>(null, true, "", controlID);
            }
        }

        //Button to add new viewer
        //ScriptableVariable picker section
        //Area to display it's current value - object field for gameObject
        //A bool to say if to follow or not
        //Button to delete the section
    }
}