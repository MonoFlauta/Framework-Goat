using System;
using System.Collections.Generic;

namespace FrameworkGoat.ObjectPool
{

    public class ObjectPool<T> : AbstractObjectPool
    {
        private List<T> _currentStock;
        private Func<T> _factoryMethod;
        private bool _isDynamic;
        private Action<T> _turnOnCallback;
        private Action<T> _turnOffCallback;

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOffCallback = turnOffCallback;
            _turnOnCallback = turnOnCallback;

            _currentStock = new List<T>();

            for (int i = 0; i < initialStock; i++)
            {
                var o = _factoryMethod();
                _turnOffCallback(o);
                _currentStock.Add(o);
            }
        }

        /// <summary>
        /// Creates an object pool with a given initial stock
        /// </summary>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock of objects</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, List<T> initialStock, bool isDynamic = true)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _turnOffCallback = turnOffCallback;
            _turnOnCallback = turnOnCallback;

            _currentStock = initialStock;
        }

        /// <summary>
        /// Gets an object from the pool. If there aren't any, and the pool is dynamic, it will create a new one. If there aren't any, and the pool isn't dynamic, it will return the default of T
        /// </summary>
        /// <returns>Object from the pool</returns>
        public T GetObject()
        {
            var result = default(T);
            if (_currentStock.Count > 0)
            {
                result = _currentStock[0];
                _currentStock.RemoveAt(0);
            }
            if (_isDynamic)
                result = _factoryMethod();
            _turnOnCallback(result);
            return result;
        }

        /// <summary>
        /// Method to return objects
        /// </summary>
        /// <param name="o">The object you want to return</param>
        public void ReturnObject(T o)
        {
            _turnOffCallback(o);
            _currentStock.Add(o);
        }
    }
}