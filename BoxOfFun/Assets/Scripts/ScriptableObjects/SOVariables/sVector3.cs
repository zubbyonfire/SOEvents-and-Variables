using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sVector3", order = 1)]
public class sVector3 : ScriptableVariable, IResetScriptableObject, ISerializationCallbackReceiver
{
    //Float value
    public Vector3 value;

    //Can the value be reset in game
    public bool resettable;

    //When the game starts, the starting value we use (so we can reset if need be)
    private Vector3 startingValue;

    /// <summary>
    /// Set sVector3 value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(Vector3 _value)
    {
        value = _value;
    }

    /// <summary>
    /// Set value to another sVector3 value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(sVector3 _value)
    {
        value = _value.value;
    }

    /// <summary>
    /// Add a Vector3 value to the value
    /// </summary>
    /// <param name="_value"></param>
    public void AddValue(Vector3 _value)
    {
        value += _value;
    }

    /// <summary>
    /// Add another sVector3 value to the value
    /// </summary>
    /// <param name="_value"></param>
    public void AddValue(sVector3 _value)
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
    public override void ResetValue()
    {
        if (resettable)
        {
            value = startingValue;
        }
    }
}
