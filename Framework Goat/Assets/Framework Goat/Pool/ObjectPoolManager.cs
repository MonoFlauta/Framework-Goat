using System.Collections.Generic;

namespace FrameworkGoat.ObjectPool
{
    public class ObjectPoolManager
    {
        private Dictionary<System.Type, AbstractObjectPool> _pools;

        /// <summary>
        /// Creates the Object Pool Manager
        /// </summary>
        public ObjectPoolManager()
        {
            _pools = new Dictionary<System.Type, AbstractObjectPool>();
        }

        /// <summary>
        /// Adds a new Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the pool</typeparam>
        /// <param name="factoryMethod">The method that returns an object</param>
        /// <param name="turnOnCallback">The turn on callback</param>
        /// <param name="turnOffCallback">The turn off callback</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">Wether the pool is dynamic or not</param>
        public void AddObjectPool<T>(ObjectPool<T>.FactoryMethod factoryMethod, ObjectPool<T>.ChangeObjectState turnOnCallback, ObjectPool<T>.ChangeObjectState turnOffCallback, int initialStock = 0, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if(!_pools.ContainsKey(typeof(T)))
                _pools.Add(typeof(T), new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Adds a new Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the pool</typeparam>
        /// <param name="factoryMethod">The method that returns an object</param>
        /// <param name="turnOnCallback">The turn on callback</param>
        /// <param name="turnOffCallback">The turn off callback</param>
        /// <param name="initialStock">The initial stock already created</param>
        /// <param name="isDynamic">Wether the pool is dynamic or not</param>
        public void AddObjectPool<T>(ObjectPool<T>.FactoryMethod factoryMethod, ObjectPool<T>.ChangeObjectState turnOnCallback, ObjectPool<T>.ChangeObjectState turnOffCallback, List<T> initialStock, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if (!_pools.ContainsKey(typeof(T)))
                _pools.Add(typeof(T), new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Gets an Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the object pool</typeparam>
        /// <returns>The object pool that contains T type</returns>
        public ObjectPool<T> GetObjectPool<T>()
        {
            return (ObjectPool<T>)_pools[typeof(T)];
        }

        /// <summary>
        /// Gets an object from a pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>The object of T type</returns>
        public T GetObject<T>()
        {
            return ((ObjectPool<T>)_pools[typeof(T)]).GetObject();
        }

        /// <summary>
        /// Returns an object to the pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="o">The object of T type</param>
        public void ReturnObject<T>(T o)
        {
            ((ObjectPool<T>)_pools[typeof(T)]).ReturnObject(o);
        }
    }
}