using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sFloat", order = 1)]
public class sFloat : ScriptableObject, IResetScriptableObject, ISerializationCallbackReceiver
{
    //Float value
    public float value;

    //Can the value be reset in game
    public bool resettable;

    //When the game starts, the starting value we use (so we can reset if need be)
    private float startingValue;

    /// <summary>
    /// Set sFloat value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(float _value)
    {
        value = _value;
    }

    /// <summary>
    /// Set value to another sBool value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(sFloat _value)
    {
        value = _value.value;
    }

    /// <summary>
    /// Add a float value to the value
    /// </summary>
    /// <param name="_value"></param>
    public void AddValue(float _value)
    {
        value += _value;
    }

    /// <summary>
    /// Add another sFloat value to the value
    /// </summary>
    /// <param name="_value"></param>
    public void AddValue(sFloat _value)
    {
        value += _value.value;
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
    public void ResetValue()
    {
        if (resettable)
        {
            value = startingValue;
        }
    }
}
