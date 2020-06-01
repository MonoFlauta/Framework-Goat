using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkGoat
{
    public class CoroutineManager : MonoBehaviour
    {
        private static CoroutineManager _instance;

        /// <summary>
        /// Singleton of the Instance
        /// </summary>
        public static CoroutineManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameObject("CoroutineManager").AddComponent<CoroutineManager>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }

        private readonly Dictionary<string, Coroutine> _currentCoroutines = new Dictionary<string, Coroutine>();

        /// <summary>
        /// Begins a new coroutine
        /// </summary>
        /// <param name="index">Index name of the coroutine</param>
        /// <param name="enumerator">Enumerator for the coroutine</param>
        /// <param name="safeCheck">Check if already had coroutine working, if it had, stop it</param>
        public void BeginCoroutine(string index, IEnumerator enumerator, bool safeCheck = false)
        {
            if(safeCheck && _currentCoroutines.ContainsKey(index))
                    StopCoroutine(_currentCoroutines[index]);
            _currentCoroutines[index] = StartCoroutine(enumerator);
        }

        /// <summary>
        /// Stops a coroutine
        /// </summary>
        /// <param name="index">Index name of the coroutine</param>
        public void EndCoroutine(string index)
        {
            StopCoroutine(_currentCoroutines[index]);
            _currentCoroutines.Remove(index);
        }

        /// <summary>
        /// Stops all coroutines
        /// </summary>
        public void EndAllCoroutines()
        {
            StopAllCoroutines();
            _currentCoroutines.Clear();
        }
    }
}