using UnityEngine;

namespace FrameworkGoat
{
    public static class VectorExtensions
    {

        /// <summary>
        /// Converts a Vector3 to a Vector2 using only it's x and y values
        /// </summary>
        /// <param name="vector">Vector3 to use</param>
        /// <returns>Returns the Vector2</returns>
        public static Vector2 ConvertV3ToV2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        /// <summary>
        /// Sets the X value to a Vector2
        /// </summary>
        /// <param name="vector">Vector2 to use</param>
        /// <param name="x">X value to assign</param>
        /// <returns>Returns the Vector2 with it's value</returns>
        public static Vector2 SetX(this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }

        /// <summary>
        /// Sets the Y value to a Vector2
        /// </summary>
        /// <param name="vector">Vector2 to use</param>
        /// <param name="Y">Y value to assign</param>
        /// <returns>Returns the Vector2 with it's value</returns>
        public static Vector2 SetY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }

        /// <summary>
        /// Sets the X value to a Vector3
        /// </summary>
        /// <param name="vector">Vector3 to use</param>
        /// <param name="x">X value to assign</param>
        /// <returns>Returnts the Vector3 with it's value</returns>
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        /// <summary>
        /// Sets the Y value to a Vector3
        /// </summary>
        /// <param name="vector">Vector3 to use</param>
        /// <param name="y">Y value to assign</param>
        /// <returns>Returnts the Vector3 with it's value</returns>
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        /// <summary>
        /// Sets the Z value to a Vector3
        /// </summary>
        /// <param name="vector">Vector3 to use</param>
        /// <param name="z">Z value to assign</param>
        /// <returns>Returnts the Vector3 with it's value</returns>
        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }
    }
}