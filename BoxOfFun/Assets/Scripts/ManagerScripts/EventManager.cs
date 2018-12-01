using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The EventManager is a singleton class which allows objects to communicate without directly referencing each other.
//Other classes can REGISTER and UNREGISTER from events, and also DISPATCH events when appropriate
public class EventManager {
    //The event dictionary links strings with event methods. A dictionary can be searched by string, and will return each event registered to that string.
    //Each event method belongs to another class, and is passed to the event manager when it is registered
    private Dictionary<string, List<Action<object>> > eventDictionary;

    //A static INSTANCE of the EventManager
    private static EventManager mInstance;

    //Note: the constructor is PRIVATE, so no other class/object can create an EventManager
    private EventManager () {
        //Create the dictionary when the class is created
        eventDictionary = new Dictionary<string, List<Action<object>> > ();
    }

    //Accessor method for the EventManager.
    //This is the ONLY way to gain access to the class, but it can be called ANYWHERE
    public static EventManager Instance {
        get {
            //If the instance doesn't yet exist, call the contstructor. This will only ever happen once.
            if (mInstance == null) {
                mInstance = new EventManager ();
            }
            return mInstance;
        }
    }

    //Register for an event:
    //Attach a specific external method to an event string
    public static void RegisterEvent (string eventName, Action<object> method) {
        //If there aren't any methods registered to this string yet, create a dictionary entry for the string
        if (!EventManager.Instance.eventDictionary.ContainsKey (eventName)) {
            EventManager.Instance.eventDictionary[eventName] = new List<Action<object>> ();
        }
        //Add the method to the list
        EventManager.Instance.eventDictionary[eventName].Add (method);
    }

    //Unregister from an event:
    //Remove a specific external method's attachment to an event string
    public static void UnregisterEvent (string eventName, Action<object> method) {
        //If this event string exists
        if (EventManager.Instance.eventDictionary.ContainsKey (eventName)) {
            //If we find our method, remove it from the list
            if (EventManager.Instance.eventDictionary[eventName].Contains (method)) {
                EventManager.Instance.eventDictionary[eventName].Remove (method);
            }
        }
    }

    //Dispatch an event:
    //Call all methods registered to that event, and pass them the game object which has dispatched the event
    public static void DispatchEvent (string eventName, object obj) {
        if (EventManager.Instance.eventDictionary.ContainsKey (eventName)) {
            //Invoke every method associated with this string
            foreach (Action<object> item in EventManager.Instance.eventDictionary[eventName].ToArray()) {
                item.Invoke (obj);
            }
        }
    }
}