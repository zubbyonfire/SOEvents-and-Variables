using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectVariable
{
    public abstract class ScriptableVariable : ScriptableObject
    {
        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public abstract void ResetValue();
    }
}
