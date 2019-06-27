using System.Collections.Generic;
using UnityEngine;

namespace FrameworkGoat
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a random item from the list
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">The list</param>
        /// <returns>Random item</returns>
        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count - 1)];
        }

        /// <summary>
        /// Shuffles the list
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">The list</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i > 1; i--)
            {
                int j = Random.Range(0, i + 1);
                T value = list[j];
                list[j] = list[i];
                list[i] = value;
            }
        }
    }
}