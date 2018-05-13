using System.Collections.Generic;

namespace FrameWorkGoat.ObjectPool
{

    public class ObjectPool<T>
    {

        public delegate T FactoryMethod();
        public delegate void ChangeObjectState(T o);

        private List<T> _currentStock;
        private FactoryMethod _factoryMethod;
        private bool _isDynamic;
        private ChangeObjectState _turnOnCallback;
        private ChangeObjectState _turnOffCallback;

        /// <summary>
        /// Creates a Pool and it's stock
        /// </summary>
        /// <param name="factoryMethod">The method that returns an object</param>
        /// <param name="turnOnCallback">The turn on callback</param>
        /// <param name="turnOffCallback">The turn off callback</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">Wether the pool is dynamic or not</param>
        public ObjectPool(FactoryMethod factoryMethod, ChangeObjectState turnOnCallback, ChangeObjectState turnOffCallback, int initialStock = 0, bool isDynamic = true)
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
        /// Creates a Pool with a given stock
        /// </summary>
        /// <param name="factoryMethod">The method that returns an object</param>
        /// <param name="turnOnCallback">The turn on callback</param>
        /// <param name="turnOffCallback">The turn off callback</param>
        /// <param name="initialStock">The initial stock already created</param>
        /// <param name="isDynamic">Wether the pool is dynamic or not</param>
        public ObjectPool(FactoryMethod factoryMethod, ChangeObjectState turnOnCallback, ChangeObjectState turnOffCallback, List<T> initialStock, bool isDynamic = true)
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