using System.Collections.Generic;

namespace FrameworkGoat.EventManager
{
    public class EventManager
    {
        /// <summary>
        /// Singleton of the Instance
        /// </summary>
        public static EventManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventManager();
                return _instance;
            }
        }
        public delegate void EventCallback(params object[] parameters);

        private static EventManager _instance;
        private Dictionary<string, EventCallback> _events;

        /// <summary>
        /// Creates a new EventManager
        /// </summary>
        private EventManager()
        {
            _events = new Dictionary<string, EventCallback>();
        }

        /// <summary>
        /// Subscribes to an event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="callback">Callback of EventCallback type</param>
        public void Subscribe(string eventName, EventCallback callback)
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
        /// <param name="callback">Callback of EventCallback type</param>
        public void Unsubscribe(string eventName, EventCallback callback)
        {
            _events[eventName] -= callback;
        }

        /// <summary>
        /// Fires an event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="parameters">Parameters</param>
        public void FireEvent(string eventName, params object[] parameters)
        {
            if (_events.ContainsKey(eventName))
                _events[eventName](parameters);
        }
    }
}