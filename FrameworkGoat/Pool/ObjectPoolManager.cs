using System;
using System.Collections.Generic;

namespace FrameworkGoat
{
    public class ObjectPoolManager
    {
        private static ObjectPoolManager _instance;
        public static ObjectPoolManager Instance
        {
            get
            {
                if (_instance == null) _instance = new ObjectPoolManager();
                return _instance;
            }
        }

        private readonly Dictionary<string, AbstractObjectPool> _pools;

        /// <summary>
        /// Creates the Object Pool Manager
        /// </summary>
        public ObjectPoolManager()
        {
            _pools = new Dictionary<string, AbstractObjectPool>();
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
        {
            if(!_pools.ContainsKey(typeof(T)+"ByType"))
                _pools.Add(typeof(T) + "ByType", new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="poolName">The pool name</param>
        /// <param name="initialStock">The initial stock that will be created</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, string poolName, int initialStock = 0, bool isDynamic = true)
        {
            if (!_pools.ContainsKey(poolName))
                _pools.Add(poolName, new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock of objects</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, List<T> initialStock, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if (!_pools.ContainsKey(typeof(T) + "ByType"))
                _pools.Add(typeof(T) + "ByType", new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Creates an object pool
        /// </summary>
        /// <typeparam name="T">The type of the pool</typeparam>
        /// <param name="factoryMethod">Factory method to create objects</param>
        /// <param name="turnOnCallback">Callback to turn on the object</param>
        /// <param name="turnOffCallback">Callback to turn off the object</param>
        /// <param name="initialStock">The initial stock of the objects</param>
        /// <param name="poolName">The pool name</param>
        /// <param name="isDynamic">If the pool is dynamic</param>
        public void AddObjectPool<T>(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, List<T> initialStock, string poolName, bool isDynamic = true) where T : AbstractObjectPool, new()
        {
            if (!_pools.ContainsKey(poolName))
                _pools.Add(poolName, new ObjectPool<T>(factoryMethod, turnOnCallback, turnOffCallback, initialStock, isDynamic));
        }

        /// <summary>
        /// Adds an existing Object Pool if it doesn't have already one of that type
        /// </summary>
        /// <param name="pool">Pool to be added</param>
        public void AddObjectPool(AbstractObjectPool pool)
        {
            if (!_pools.ContainsKey(pool.GetType() + "ByType"))
                _pools.Add(pool.GetType() + "ByType", pool);
        }

        /// <summary>
        /// Adds an existing Object Pool if it doesn't have already one with that index
        /// </summary>
        /// <param name="pool">Pool to be added</param>
        /// <param name="poolName">Pool name</param>
        public void AddObjectPool(AbstractObjectPool pool, string poolName)
        {
            if (_pools.ContainsKey(poolName))
                _pools.Add(poolName, pool);
        }

        /// <summary>
        /// Gets an Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the object pool</typeparam>
        /// <returns>The object pool that contains T type</returns>
        public ObjectPool<T> GetObjectPool<T>()
        {
            return (ObjectPool<T>)_pools[typeof(T) + "ByType"];
        }

        /// <summary>
        /// Gets an Object Pool
        /// </summary>
        /// <typeparam name="T">Type of the object pool</typeparam>
        /// <param name="poolName">The name of the pool</param>
        /// <returns>The object pool that contains T type</returns>
        public ObjectPool<T> GetObjectPool<T>(string poolName)
        {
            return (ObjectPool<T>)_pools[poolName];
        }

        /// <summary>
        /// Gets an object from a pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <returns>The object of T type</returns>
        public T GetObject<T>()
        {
            return ((ObjectPool<T>)_pools[typeof(T) + "ByType"]).GetObject();
        }

        /// <summary>
        /// Gets an object from a pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="poolName">The name of the pool</param>
        /// <returns>The object of T type</returns>
        public T GetObject<T>(string poolName)
        {
            return ((ObjectPool<T>)_pools[poolName]).GetObject();
        }

        /// <summary>
        /// Returns an object to the pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="o">The object of T type</param>
        public void ReturnObject<T>(T o)
        {
            ((ObjectPool<T>)_pools[typeof(T) + "ByType"]).ReturnObject(o);
        }

        /// <summary>
        /// Returns an object to the pool
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="o">The object of T type</param>
        /// <param name="poolName">Pool name</param>
        public void ReturnObject<T>(T o, string poolName)
        {
            ((ObjectPool<T>)_pools[poolName]).ReturnObject(o);
        }

        /// <summary>
        /// Removes a pool
        /// </summary>
        /// <typeparam name="T">Type of the pool</typeparam>
        public void RemovePool<T>()
        {
            _pools.Remove(typeof(T) + "ByType");
        }

        /// <summary>
        /// Removes a pool
        /// </summary>
        /// <param name="poolName">Pool name</param>
        public void RemovePool(string poolName)
        {
            _pools.Remove(poolName);
        }
    }
}