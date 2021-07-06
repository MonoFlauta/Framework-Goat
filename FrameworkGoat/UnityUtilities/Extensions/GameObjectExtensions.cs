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
            for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }
}