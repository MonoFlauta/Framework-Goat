using UnityEngine;

namespace FrameworkGoat
{
    public static class RigidbodyExtensions
    {
        /// <summary>
        /// Changes the direction of a Ridigbody velocity
        /// </summary>
        /// <param name="rb">The Rigidbody</param>
        /// <param name="direction">The new direction</param>
        public static void ChangeDirection(this Rigidbody rb, Vector3 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }

        /// <summary>
        /// Changes the direction of a Rigidbody velocity
        /// </summary>
        /// <param name="rb">The Rigidbody</param>
        /// <param name="direction">The new direction</param>
        public static void ChangeDirection(this Rigidbody2D rb, Vector2 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }

        /// <summary>
        /// Normalizes velocity of a Rigidbody
        /// </summary>
        /// <param name="rb">Rigidbody</param>
        /// <param name="magnitude">New magnitude</param>
        public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }

        /// <summary>
        /// Normalizes velocity of a Rigidbody
        /// </summary>
        /// <param name="rb">Rigidbody</param>
        /// <param name="magnitude">New magnitude</param>
        public static void NormalizeVelocity(this Rigidbody2D rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }
    }
}