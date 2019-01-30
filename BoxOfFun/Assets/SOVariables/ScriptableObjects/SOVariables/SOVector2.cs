using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "sVector2", menuName = "sVariables/sVector2", order = 1)]

    public class SOVector2 : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public Vector2 value;

        //Can the value be reset in game
        //public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private Vector2 startingValue;

        /// <summary>
        /// Set sVector3 value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(Vector2 _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sVector3 value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOVector2 _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Add a Vector3 value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(Vector2 _value)
        {
            value += _value;
        }

        /// <summary>
        /// Add another sVector3 value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOVector2 _value)
        {
            value += _value.value;
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
