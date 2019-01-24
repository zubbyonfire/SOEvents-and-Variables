using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "sBool", menuName = "sVariables/sBool", order = 1)]
    public class SOBool : ScriptableVariable, IResetScriptableObject, ISerializationCallbackReceiver
    {
        [KeyValue] public bool value;

        //Can the value be reset in game
        public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        private bool startingValue;

        /// <summary>
        /// Set sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(bool _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOBool _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Swap the bool value
        /// </summary>
        public void Toggle()
        {
            value = !value;
        }

        /// <summary>
        /// Recieve callback after unity deseriallzes the object
        /// </summary>
        public void OnAfterDeserialize()
        {
            startingValue = value;
        }

        public void OnBeforeSerialize() { }

        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public override void ResetValue()
        {
            if (resettable)
            {
                value = startingValue;
            }
        }
    }
}
