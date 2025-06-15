using System;
using System.Collections.Generic;
using _Scripts.Utilities.Patterns;
using UnityEngine;

namespace _Scripts.Utilities.Sounds
{
    public class SoundManager : SingletonsPersistent<SoundManager>
    {
        [System.Serializable]
        public class Sound
        {
            public string name;
            public AudioClip clip;
            public SoundCategory category;
        }

        [SerializeField] private List<Sound> sounds;
        
        private Dictionary<SoundCategory, AudioSource> _audioSources;
        private Dictionary<string, AudioClip> _soundDictionary;

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            SoundEvent.OnPlaySound += PlaySound;
        }
        
        private void OnDisable()
        {
            SoundEvent.OnPlaySound -= PlaySound;
        }

        private void InitializeSoundManager()
        {
            _audioSources = new Dictionary<SoundCategory, AudioSource>();
            _soundDictionary = new Dictionary<string, AudioClip>();

            foreach (var category in System.Enum.GetValues(typeof(SoundCategory)))
            {
                var source = gameObject.AddComponent<AudioSource>();
                source.loop = (category == (object)SoundCategory.Music);
                _audioSources.Add((SoundCategory)category, source);
            }

            foreach (var sound in sounds)
            {
                _soundDictionary.Add(sound.name, sound.clip);
            }
        }
        
        public void PlaySound(string soundName)
        {
            if (_soundDictionary.TryGetValue(soundName, out var clip))
            {
                var category = sounds.Find(s => s.name == soundName).category;
                _audioSources[category].PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning($"Sound {soundName} not found in sound manager");
            }
        }
        
        public void SetVolume(SoundCategory category, float volume)
        {
            if (_audioSources.TryGetValue(category, out var source))
            {
                source.volume = Mathf.Clamp01(volume);
            }
        }
        
        public void StopSound(SoundCategory category)
        {
            if (_audioSources.TryGetValue(category, out var source))
            {
                source.Stop();
            }
        }
    }
}