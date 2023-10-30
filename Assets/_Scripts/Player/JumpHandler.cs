using _Scripts.Configs;
using UnityEngine;

namespace _Scripts.Player
{
    public class JumpHandler
    {
        private float _jumpVelocity;
        
        private GravityHandler _gravityHandler;

        public JumpHandler(float jumpTime, float jumpHeight, GravityHandler gravityHandler)
        {
            _gravityHandler = gravityHandler;
            
            var maxHeightTime = jumpTime / 2;
            _gravityHandler.SetGravityForce((2 * jumpHeight) / Mathf.Pow(maxHeightTime, 2));
            _jumpVelocity = (2 * jumpHeight) / maxHeightTime;
        }

        public Vector3 HandleJump(Vector3 direction)
        {
            direction.y = _jumpVelocity;
            return direction;
        }
    }
}