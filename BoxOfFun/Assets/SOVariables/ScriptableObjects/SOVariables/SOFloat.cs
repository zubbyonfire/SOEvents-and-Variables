using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sFloat", order = 1)]
    public class SOFloat : ScriptableVariable, IResetScriptableObject, ISerializationCallbackReceiver
    {
        //Float value
        [ShowOnly][KeyValue] public float currentValue;

        //Can the value be reset in game
        public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        public float startingValue = 10;

        /// <summary>
        /// Set sFloat value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(float _value)
        {
            currentValue = _value;
        }

        /// <summary>
        /// Set value to another sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOFloat _value)
        {
            currentValue = _value.currentValue;
        }

        /// <summary>
        /// Add a float value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(float _value)
        {
            currentValue += _value;
        }

        /// <summary>
        /// Add another sFloat value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOFloat _value)
        {
            currentValue += _value.currentValue;
        }

        /// <summary>
        /// Recieve callback after unity deseriallzes the object
        /// </summary>
        public void OnAfterDeserialize()
        {
            currentValue = startingValue;
        }

        public void OnBeforeSerialize() { }

        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public override void ResetValue()
        {
            if (resettable)
            {
                currentValue = startingValue;
            }
        }
    }
}
