using System.Collections;
using _Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        private GravityHandler _gravityHandler;
        private JumpHandler _jumpHandler;
        private CharacterController _controller;
        private DashTimer _dashTimer;

        private float _speed;
        
        private float _dashDistance;
        private float _dashSpeed = 20f;
        private float _dashTime;

        private Vector3 _moveDirection;

        [Inject]
        public void Init(PlayerConfig config)
        {
            _controller = GetComponent<CharacterController>();
            
            _speed = config.GetSpeed();
            
            _dashDistance = config.GetDashDistance();
            _dashSpeed = config.GetDashSpeed();
            
            _gravityHandler = new GravityHandler(config.GetGravityForce());
            _jumpHandler = new JumpHandler(config.GetJumpTime(), config.GetJumpHeight(), ref _gravityHandler);
            
            _dashTimer = GetComponent<DashTimer>();
            _dashTimer.Init(config.GetDashCount(), config.GetDashRecoveryTime(), config.GetDashRate());
            _dashTime = _dashDistance / _dashSpeed;
        }

        public void TryMove()
        {
            Move();
        }

        public void TryDash()
        {
            if (_dashTimer.CheckAbility())
                StartCoroutine(Dash());

        }

        public void TryJump()
        {
            if (_controller.isGrounded) Jump();
        }
        
        public void UpdateDirection(Vector2 input)
        {
            var y = _moveDirection.y;
            _moveDirection = -(transform.forward * input.y + transform.right * input.x) * _speed;
            _moveDirection.y = y;
            ApplyGravity();
        }

        private void Jump() => _jumpHandler.HandleJump(ref _moveDirection);

        private IEnumerator Dash()
        {
            var startTime = Time.time;
            _dashTimer.PerformAbility();

            var dashDirection = _moveDirection;
            
            while (startTime + _dashTime > Time.time)
            {
                _controller.Move(dashDirection * (_dashSpeed * Time.deltaTime));
                yield return null;
            }
            
        }
    
        private void Move() => _controller.Move(_moveDirection * Time.deltaTime);
        private void ApplyGravity() =>  _gravityHandler.ApplyGravity(ref _moveDirection);
    }
}