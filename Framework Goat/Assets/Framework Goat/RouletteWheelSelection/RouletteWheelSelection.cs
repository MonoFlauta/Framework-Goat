using System;
using System.Collections.Generic;

namespace FrameworkGoat
{
    public class RouletteWheelSelection<T>
    {
        private Dictionary<T, int> _values;
        private Random _random;

        /// <summary>
        /// Creates a Roulette Wheel Selection
        /// </summary>
        public RouletteWheelSelection()
        {
            _values = new Dictionary<T, int>();
            _random = new Random();
        }

        /// <summary>
        /// Adds a new value
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="weight">It's weight</param>
        public void AddValue(T obj, int weight)
        {
            _values.Add(obj, weight);
        }

        /// <summary>
        /// Removes a value
        /// </summary>
        /// <param name="obj">The object</param>
        public void RemoveValue(T obj)
        {
            _values.Remove(obj);
        }

        /// <summary>
        /// Gets a value
        /// </summary>
        /// <returns>Returns the object after apllying the roulette wheel selection</returns>
        public T GetValue()
        {
            int total = 0;
            foreach(var item in _values)
            {
                total += item.Value;
            }
            _random.Next(0, total);
            foreach(var item in _values)
            {
                total -= item.Value;
                if (total <= 0) return item.Key;
            }
            return default(T);
        }

        /// <summary>
        /// Removes all the objects with their weights
        /// </summary>
        public void ResetValues()
        {
            _values = new Dictionary<T, int>();
        }
    }
}