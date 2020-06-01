using System;
using System.Collections.Generic;

namespace FrameworkGoat
{
    public class EventManager
    {
        private static EventManager _instance;


        /// <summary>
        /// Singleton of the Instance
        /// </summary>
        public static EventManager Instance
        {
            get
            {
                if (_instance == null) _instance = new EventManager();
                return _instance;
            }
        }
        
        private Dictionary<string, Action<Event>> _events;

        /// <summary>
        /// Creates a new EventManager
        /// </summary>
        private EventManager()
        {
            _events = new Dictionary<string, Action<Event>>();
        }

        /// <summary>
        /// Subscribes to an event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="callback">Callback</param>
        public void Subscribe(string eventName, Action<Event> callback)
        {
            if (!_events.ContainsKey(eventName) || _events[eventName] == null)
                _events[eventName] = callback;
            else
                _events[eventName] += callback;
        }

        /// <summary>
        /// Unsubscribes to an event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="callback">Callback</param>
        public void Unsubscribe(string eventName, Action<Event> callback)
        {
            _events[eventName] -= callback;
            if (_events[eventName] == null) _events.Remove(eventName);
        }

        /// <summary>
        /// Fires an event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="e">Event</param>
        public void FireEvent(string eventName, Event e = null)
        {
            if (_events.ContainsKey(eventName))
                _events[eventName](e);
        }

        /// <summary>
        /// Clears all the events
        /// </summary>
        public void Clear()
        {
            _events.Clear();
        }

        /// <summary>
        /// Subscribes clear to an event
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        public void SubscribeClear(string eventName)
        {
            Subscribe(eventName, (e) => Clear());
        }
    }
}