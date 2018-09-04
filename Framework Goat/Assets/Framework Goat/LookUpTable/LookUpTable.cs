using System;
using System.Collections.Generic;

namespace FrameworkGoat
{
    public class LookUpTable<T, T2>
    {
        private Func<T2, T> _factoryMethod;
        private Dictionary<T2, T> _table;

        /// <summary>
        /// Creates a Look Up Table.
        /// </summary>
        /// <param name="factoryMethod">The factory method rule</param>
        public LookUpTable(Func<T2, T> factoryMethod)
        {
            _factoryMethod = factoryMethod;
            _table = new Dictionary<T2, T>();
        }

        /// <summary>
        /// Pre-calculates values. Useful for loading screens.
        /// </summary>
        /// <param name="value">The value to pre-calculate and store</param>
        public void PreCalculateValue(T2 value)
        {
            _table[value] = _factoryMethod(value);
        }

        /// <summary>
        /// Returns the value if already calculated. If not, it creates it and calculates it.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>Returns the result</returns>
        public T GetValue(T2 value)
        {
            if (!_table.ContainsKey(value)) PreCalculateValue(value);
            return _table[value];
        }
    }
}