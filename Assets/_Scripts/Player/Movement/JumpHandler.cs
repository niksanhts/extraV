using UnityEngine;

namespace _Scripts.Player
{
    public class JumpHandler
    {
        private float _jumpVelocity;
        
        public JumpHandler(float jumpTime, float jumpHeight, ref GravityHandler gravityHandler)
        {
            var maxHeightTime = jumpTime / 2;
            gravityHandler.SetGravityForce((2 * jumpHeight) / Mathf.Pow(maxHeightTime, 2));
            _jumpVelocity = (30 * jumpHeight) / maxHeightTime;
        }

        public Vector3 HandleJump(ref Vector3 direction)
        {
            direction.y = _jumpVelocity;
            return direction;
        }

        
    }
}