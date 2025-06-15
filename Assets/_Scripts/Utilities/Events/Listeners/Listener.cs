using _Scripts.Utilities.Events.ISOs;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Utilities.Events.Listeners
{
    public class Listener<T, TIso, TUe> : MonoBehaviour, IListener<T> where TIso : EventIso<T> where TUe : UnityEvent<T>
    {
        public TIso channel;
        public TUe callBacks;

        private void OnEnable()
        {
            if (channel == null) return;
            channel.Register(this);
        }

        private void OnDisable()
        {
            if (channel == null) return;
            channel.Unregister(this);
        }

        public void Raise(T item)
        {
            
        }
    }
}