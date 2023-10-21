using _Scripts.Configs;
using UnityEngine;

namespace _Scripts.Player
{
    public class JumpHandler
    {
        private float _jumpVelocity;
        
        private float _jumpTime;
        private float _jumpHeight;
        private GravityHandler _gravityHandler;

        public JumpHandler(PlayerConfig config, GravityHandler gravityHandler)
        {
            _jumpTime = config.GetJumpDistance();
            _jumpHeight = config.GetJumpHeight();
            _gravityHandler = gravityHandler;
            
            var maxHeightTime = _jumpTime / 2;
            _gravityHandler.SetGravityForce((2 * _jumpHeight) / Mathf.Pow(maxHeightTime, 2));
            _jumpVelocity = (2 * _jumpHeight) / maxHeightTime;
        }

        public Vector3 HandleJump(Vector3 direction)
        {
            direction.y = _jumpVelocity;
            return direction;
        }
    }
}