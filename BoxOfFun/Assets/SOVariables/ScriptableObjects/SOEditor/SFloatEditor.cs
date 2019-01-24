using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOFloat))]
    [CanEditMultipleObjects]
    public class SFloatEditor : Editor
    {
#if UNITY_EDITOR
        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOFloat script = (SOFloat)target;

            if (script.resettable)
            {
                if (GUILayout.Button("Reset Value"))
                {
                    if (EditorApplication.isPlaying)
                    {
                        script.ResetValue();
                    }
                }
            }
        }
#endif
    }
}
