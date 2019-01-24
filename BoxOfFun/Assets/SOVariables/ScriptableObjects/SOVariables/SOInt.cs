using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sInt", order = 1)]
    public class SOInt : ScriptableVariable, IResetScriptableObject, ISerializationCallbackReceiver
    {
        //Float value
        public int value;

        //Can the value be reset in game
        public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        private int startingValue;

        /// <summary>
        /// Set sInt value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(int _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sInt value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOInt _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Recieve callback after unity deseriallzes the object
        /// </summary>
        public void OnAfterDeserialize()
        {
            startingValue = value;
        }

        /// <summary>
        /// Add a int value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(int _value)
        {
            value += _value;
        }

        /// <summary>
        /// Add another sInt value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOInt _value)
        {
            value += _value.value;
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
