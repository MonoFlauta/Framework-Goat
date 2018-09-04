using System.Collections.Generic;
using UnityEngine;

namespace FrameworkGoat
{
    public class SoundController : MonoBehaviour
    {

        private Dictionary<string, AudioSource> _audioSources;
        private AudioSource _sfx;

        void Start()
        {
            _audioSources = new Dictionary<string, AudioSource>();
            _sfx = gameObject.AddComponent<AudioSource>();
            _sfx.playOnAwake = false;
        }

        /// <summary>
        /// Adds a new theme
        /// </summary>
        /// <param name="key">Key for the theme</param>
        /// <param name="music">Audioclip</param>
        public void AddMusic(string key, AudioClip music)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = music;
            _audioSources.Add(key, audioSource);
        }

        /// <summary>
        /// Removes a theme
        /// </summary>
        /// <param name="key">Key of the theme</param>
        public void RemoveMusic(string key)
        {
            Destroy(_audioSources[key]);
            _audioSources.Remove(key);
        }

        /// <summary>
        /// Stops a theme
        /// </summary>
        /// <param name="key">Theme to stop</param>
        public void StopTheme(string key)
        {
            _audioSources[key].Stop();
        }

        /// <summary>
        /// Plays a theme
        /// </summary>
        /// <param name="key">Theme to play</param>
        public void PlayTheme(string key)
        {
            _audioSources[key].Play();
        }

        /// <summary>
        /// Plays a Sound Effect
        /// </summary>
        /// <param name="sfx">The Sound Effect</param>
        public void PlaySFX(AudioClip sfx)
        {
            _sfx.PlayOneShot(sfx);
        }

        /// <summary>
        /// Sets a volume to a theme
        /// </summary>
        /// <param name="key">Key of the theme</param>
        /// <param name="volume">Volume for the theme</param>
        public void SetVolume(string key, float volume)
        {
            _audioSources[key].volume = volume;
        }

        /// <summary>
        /// Gives the volume of a theme
        /// </summary>
        /// <param name="key">Key of the theme</param>
        /// <returns>The volume</returns>
        public float GetVolume(string key)
        {
            return _audioSources[key].volume;
        }

        /// <summary>
        /// Sets all the audiosources to the same volume
        /// </summary>
        /// <param name="volume">Volume to set</param>
        /// <param name="includeSFX">If it should include the sfx audiosource</param>
        public void SetAllVolumes(float volume, bool includeSFX = true)
        {
            foreach (var item in _audioSources.Values)
            {
                item.volume = volume;
            }
            if (includeSFX) _sfx.volume = volume;
        }

        /// <summary>
        /// Sets the SFX volume
        /// </summary>
        /// <param name="volume">Volume to set</param>
        public void SetSFXVolume(float volume)
        {
            _sfx.volume = volume;
        }

        /// <summary>
        /// Gets the SFX volume
        /// </summary>
        /// <returns>The volume of the sfx</returns>
        public float GetSFXVolume()
        {
            return _sfx.volume;
        }
    }
}