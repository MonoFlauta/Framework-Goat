using System;
using UnityEngine;

namespace FrameworkGoat
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LayerController : MonoBehaviour
    {
        public SortingOrder initialSortingOrder = SortingOrder.Y;

        private Func<int> _updateCallback;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetSortingOrder(initialSortingOrder);
        }

        void Update()
        {
            _spriteRenderer.sortingOrder = _updateCallback();
        }

        /// <summary>
        /// Sets the sorting order by using the enum options
        /// </summary>
        /// <param name="sortingOrder">Sorting layer</param>
        /// <param name="amplitude">Amplitude of sorting</param>
        public void SetSortingOrder(SortingOrder sortingOrder, float amplitude = 1)
        {
            switch(sortingOrder)
            {
                case SortingOrder.X:
                    _updateCallback = () => { return (int)(transform.position.x * amplitude); };
                    break;
                case SortingOrder.Y:
                    _updateCallback = () => { return (int)(transform.position.y * amplitude); };
                    break;
                case SortingOrder.Z:
                    _updateCallback = () => { return (int)(transform.position.z * amplitude); };
                    break;
            }
        }

        /// <summary>
        /// Sets the sorting order by using a Func
        /// </summary>
        /// <param name="sortingOrder">Sorting Order</param>
        public void SetSortingOrder(Func<int> sortingOrder)
        {
            _updateCallback = sortingOrder;
        }

        public enum SortingOrder
        {
            X,
            Y,
            Z
        }
    }
}