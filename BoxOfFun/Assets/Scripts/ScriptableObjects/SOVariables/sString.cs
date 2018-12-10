using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sString", order = 1)]
public class sString : ScriptableVariable, IResetScriptableObject, ISerializationCallbackReceiver
{
    //Float value
    public string value;

    //Can the value be reset in game
    public bool resettable;

    //When the game starts, the starting value we use (so we can reset if need be)
    private string startingValue;

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
    public void SetValue(sString _value)
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
