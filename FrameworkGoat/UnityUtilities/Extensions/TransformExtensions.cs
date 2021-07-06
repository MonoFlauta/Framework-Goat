using UnityEngine;

namespace FrameworkGoat
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroys all children of the transform
        /// </summary>
        /// <param name="transform">Transform to use</param>
        public static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}