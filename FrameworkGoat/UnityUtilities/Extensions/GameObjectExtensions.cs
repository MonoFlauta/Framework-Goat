using UnityEngine;

namespace FrameworkGoat
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Destroys all children of the game object
        /// </summary>
        /// <param name="gameObject">GameObject to use</param>
        public static void DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildren();
        }

        /// <summary>
        /// Resets transform's position, scale and rotation
        /// </summary>
        /// <param name="gameObject">GameObject to use</param>
        public static void ResetTransformation(this GameObject gameObject)
        {
            gameObject.transform.ResetTransformation();
        }
    }
}