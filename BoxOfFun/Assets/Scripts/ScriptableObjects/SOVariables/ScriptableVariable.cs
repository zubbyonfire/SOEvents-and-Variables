using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableVariable : ScriptableObject
{
    //Rest the value function
    /// <summary>
    /// Reset the value to it's inital value if it's resettable
    /// </summary>
    public abstract void ResetValue();
}
