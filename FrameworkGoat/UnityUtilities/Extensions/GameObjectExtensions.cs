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

        /// <summary>
        /// Gets, or adds if doesn't contain yet, a component
        /// </summary>
        /// <param name="gameObject">GameObject to use</param>
        /// <typeparam name="T">The component type</typeparam>
        /// <returns>Returns the component</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) gameObject.AddComponent<T>();
            return component;
        }
    }
}