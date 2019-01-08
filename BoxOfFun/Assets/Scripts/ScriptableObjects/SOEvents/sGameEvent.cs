using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sGameEvent", menuName = "sGameEvents/sGameEvent", order = 1)]
public class sGameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    [TextArea]
    public string eventDescription;

    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
