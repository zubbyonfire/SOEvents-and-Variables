using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sFloat", menuName = "sVariables/sGameObject", order = 1)]
public class sGameObject : ScriptableObject, IResetScriptableObject, ISerializationCallbackReceiver
{
    //Float value
    public GameObject value;

    //Can the value be reset in game
    public bool resettable;

    //When the game starts, the starting value we use (so we can reset if need be)
    private GameObject startingValue;

    /// <summary>
    /// Set sGameObject value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(GameObject _value)
    {
        value = _value;
    }

    /// <summary>
    /// Set value to another sGameObject value
    /// </summary>
    /// <param name="_value"></param>
    public void SetValue(sGameObject _value)
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
    public void ResetValue()
    {
        if (resettable)
        {
            value = startingValue;
        }
    }
}
