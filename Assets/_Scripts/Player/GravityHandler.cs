using UnityEngine;

namespace _Scripts.Player
{
    public class GravityHandler
    {
        private float _gravity;

        public GravityHandler(float gravity) => _gravity = gravity;

        public Vector3 ApplyGravity(Vector3 direction)
        {
            direction.y += _gravity * Time.deltaTime * Time.deltaTime;
            return direction;
        }

        public void SetGravityForce(float force) => _gravity = force;
    }
}