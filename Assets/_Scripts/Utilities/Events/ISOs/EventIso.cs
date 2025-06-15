using System.Collections.Generic;
using _Scripts.Utilities.Events.Listeners;
using UnityEngine;

namespace _Scripts.Utilities.Events.ISOs
{
    public class EventIso<T> : ScriptableObject
    {
        private readonly List<IListener<T>> _listeners = new List<IListener<T>>();

        public void Register(IListener<T> listener)
        {
            if (_listeners.Contains(listener)) return;
            _listeners.Add(listener);
        }

        public void Unregister(IListener<T> listener)
        {
            if (!_listeners.Contains(listener)) return;
            _listeners.Remove(listener);
        }

        public void Emit(T item)
        {
            for (var i = _listeners.Count - 1; i >= 0; i++)
            {
                _listeners[i].Raise(item);
            }
        }
    }
}