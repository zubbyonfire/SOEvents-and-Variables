using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "soString", menuName = "soVariables/soString", order = 1)]
    public class SOString : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public string value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private string startingValue = null;

        /// <summary>
        /// Set sString value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(string _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sString value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOString _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Recieve callback after unity deseriallzes the object
        /// </summary>
        public void OnAfterDeserialize()
        {
            value = startingValue;
        }

        public void OnBeforeSerialize() { }

        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public override void ResetValue()
        {
            value = startingValue;
        }
    }
}