using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectEvent
{
    [CreateAssetMenu(fileName = "sGameEvent", menuName = "sGameEvents/sGameEvent", order = 1)]
    public class SOGameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        private Logger myLogger;

        [TextArea]
        [Tooltip("When is this event raised")]
        public string eventDescription = "[When does this event trigger]";

        public void Raise()
        {
            myLogger = new Logger(new LogHandler());
            myLogger.Log(this.name, "Event raised");

            for (int i = listeners.Count - 1; i >= 0; i--)
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
}
