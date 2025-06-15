using System;
using UnityEngine;

namespace _Scripts.Utilities.Patterns
{
    public class Singletons<T> : MonoBehaviour
    {
        public static Singletons<T> instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogWarning($"There are multiple instances of {typeof(T)} in the scene.");
            }
        }
    }
    
    public class SingletonsPersistent<T> : MonoBehaviour
    {
        public static SingletonsPersistent<T> instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"There are multiple instances of {typeof(T)} in the scene.");
            }
        }
    }
}