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
        }

        private void OnDisable()
        {
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Add Scriptable Variable"))
            {
                int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<ScriptableVariable>(null, true, "", controlID);
            }

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
            }
        }

        private void AddScriptableVariable()
        {
            
        }
    }
}