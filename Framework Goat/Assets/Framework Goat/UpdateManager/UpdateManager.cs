using UnityEngine;
using System.Linq;

namespace FrameworkGoat
{
    public class UpdateManager : MonoBehaviour
    {
        private static UpdateManager _instance;

        /// <summary>
        /// Singleton of the Instance
        /// </summary>
        public static UpdateManager Instance
        {
            get
            {
                return _instance;
            }
        }

        void Awake()
        {
            _instance = this;
        }

        private ITick[] _ticks = new ITick[0];
        private IFixedTick[] _fixedTicks = new IFixedTick[0];
        private ILateTick[] _lateTicks = new ILateTick[0];

        /// <summary>
        /// Calls all the ticks
        /// </summary>
        private void Update()
        {
            for (int i = _ticks.Length - 1; i >= 0; i--)
                _ticks[i].Tick();
        }

        /// <summary>
        /// Calls all the fixed ticks
        /// </summary>
        private void FixedUpdate()
        {
            for (int i = _fixedTicks.Length - 1; i >= 0; i--)
                _fixedTicks[i].FixedTick();
        }

        /// <summary>
        /// Calls all the late ticks
        /// </summary>
        private void LateUpdate()
        {
            for (int i = _lateTicks.Length - 1; i >= 0; i--)
                _lateTicks[i].LateTick();
        }

        /// <summary>
        /// Adds a Tick
        /// </summary>
        /// <param name="t">Tick</param>
        public void AddTick(ITick t)
        {
            _ticks = _ticks.Concat(new ITick[] {t}).ToArray();
        }

        /// <summary>
        /// Adds a Late Tick
        /// </summary>
        /// <param name="t">Late Tick</param>
        public void AddLateTick(ILateTick t)
        {
            _lateTicks = _lateTicks.Concat(new ILateTick[] { t }).ToArray();
        }

        /// <summary>
        /// Adds a Fixed Tick
        /// </summary>
        /// <param name="t">Fixed Tick</param>
        public void AddFixedTick(IFixedTick t)
        {
            _fixedTicks = _fixedTicks.Concat(new IFixedTick[] { t }).ToArray();
        }

        /// <summary>
        /// Removes all existance of a Tick
        /// </summary>
        /// <param name="t">Tick</param>
        public void RemoveTick(ITick t)
        {
            _ticks = _ticks.Where((value) => value != t).ToArray();
        }

        /// <summary>
        /// Removes all existance of a Late Tick
        /// </summary>
        /// <param name="t">Late Tick</param>
        public void RemoveLateTick(ILateTick t)
        {
            _lateTicks = _lateTicks.Where((value) => value != t).ToArray();
        }

        /// <summary>
        /// Removes all existance of a Fixed Tick
        /// </summary>
        /// <param name="t">Fixed Tick</param>
        public void RemoveFixedTick(IFixedTick t)
        {
            _fixedTicks = _fixedTicks.Where((value) => value != t).ToArray();
        }

        /// <summary>
        /// Tells if it contains a Tick
        /// </summary>
        /// <param name="t">Tick</param>
        /// <returns>True if contains that tick</returns>
        public bool ContainsTick(ITick t)
        {
            return _ticks.Contains(t);
        }

        /// <summary>
        /// Tells if it contains a Late Tick
        /// </summary>
        /// <param name="t">Late Tick</param>
        /// <returns>True if contains that late tick</returns>
        public bool ContainsLateTick(ILateTick t)
        {
            return _lateTicks.Contains(t);
        }

        /// <summary>
        /// Tells if it contains a Fixed Tick
        /// </summary>
        /// <param name="t">Fixed Tick</param>
        /// <returns>True if contains that fixed tick</returns>
        public bool ContainsFixedTick(IFixedTick t)
        {
            return _fixedTicks.Contains(t);
        }
    }
}