using UnityEngine;

namespace _Scripts.Player
{
    public class GravityHandler
    {
        private float _gravity = 0;
        public GravityHandler(float gravity) => SetGravityForce(gravity);
        public void SetGravityForce(float force) => _gravity = force;
        public Vector3 ApplyGravity(ref Vector3 direction)
        {
            direction.y -= _gravity;
            return direction;
        }
    }
}