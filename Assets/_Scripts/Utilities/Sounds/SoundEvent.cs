using System;
using UnityEngine;

namespace _Scripts.Utilities.Sounds
{
    public class SoundEvent : MonoBehaviour
    {
        public static event Action<string> OnPlaySound;
        
        public static void PlaySound(string soundName)
        {
            OnPlaySound?.Invoke(soundName);
        }
    }
}