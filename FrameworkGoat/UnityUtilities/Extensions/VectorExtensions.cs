using System;
using System.Linq;
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
        /// Adds a value to X
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="x">Value to add</param>
        /// <returns>The vector with the value added</returns>
        public static Vector2 AddX(this Vector2 vector, float x)
        {
            return new Vector2(vector.x + x, vector.y);
        }

        /// <summary>
        /// Adds a value to Y
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="y">Value to add</param>
        /// <returns>The vector with the value added</returns>
        public static Vector2 AddY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, vector.y + y);
        }

        /// <summary>
        /// Normalizes a Vector2 to a magnitude
        /// </summary>
        /// <param name="vector">Vector to normalize</param>
        /// <param name="magnitude">New magnitude</param>
        /// <returns>The Vector3 normalized</returns>
        public static Vector2 Normalize(this Vector2 vector, float magnitude)
        {
            return vector.normalized * magnitude;
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

        /// <summary>
        /// Adds a value to X
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="x">Value to add</param>
        /// <returns>The vector with the value added</returns>
        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        /// <summary>
        /// Adds a value to Y
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="y">Value to add</param>
        /// <returns>The vector with the value added</returns>
        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        /// <summary>
        /// Adds a value to Z
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="z">Value to add</param>
        /// <returns>The vector with the value added</returns>
        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }

        /// <summary>
        /// Normalizes a Vector3 to a magnitude
        /// </summary>
        /// <param name="vector">Vector to normalize</param>
        /// <param name="magnitude">New magnitude</param>
        /// <returns>The Vector3 normalized</returns>
        public static Vector3 Normalize(this Vector3 vector, float magnitude = 1)
        {
            return vector.normalized * magnitude;
        }

        /// <summary>
        /// Gets closest vector to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Closest vector</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static Vector3 GetClosestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector3.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }
        
        /// <summary>
        /// Gets closest vector to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Closest vector</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }
        
        /// <summary>
        /// Gets closest distance to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Closest distance</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static float GetClosestDistanceFrom(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector3.Distance(vector, otherVectors[0]);
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                    minDistance = newDistance;
            }
            return minDistance;
        }
        
        /// <summary>
        /// Gets closest distance to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Closest distance</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static float GetClosestDistanceFrom(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                    minDistance = newDistance;
            }
            return minDistance;
        }
        
        /// <summary>
        /// Gets farthest vector to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Farthest vector</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static Vector3 GetFarthestVector3From(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var maxDistance = Vector3.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }
        
        /// <summary>
        /// Gets farthest vector to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Farthest vector</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static Vector2 GetFarthestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var maxDistance = Vector2.Distance(vector, otherVectors[0]);
            var maxVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                {
                    maxDistance = newDistance;
                    maxVector = otherVectors[i];
                }
            }
            return maxVector;
        }
        
        /// <summary>
        /// Gets farthest distance to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Farthest distance</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static float GetFarthestDistanceFrom(this Vector3 vector, Vector3[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var maxDistance = Vector3.Distance(vector, otherVectors[0]);
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector3.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                    maxDistance = newDistance;
            }
            return maxDistance;
        }
        
        /// <summary>
        /// Gets farthest distance to the vector given an array of vectors
        /// </summary>
        /// <param name="vector">Vector to use</param>
        /// <param name="otherVectors">Vectors to check with</param>
        /// <returns>Farthest distance</returns>
        /// <exception cref="Exception">The list of other vectors is empty</exception>
        public static float GetFarthestDistanceFrom(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var maxDistance = Vector2.Distance(vector, otherVectors[0]);
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance > maxDistance)
                    maxDistance = newDistance;
            }
            return maxDistance;
        }
    }
}