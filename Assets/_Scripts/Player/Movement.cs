using System;
using _Scripts.Configs;
using _Scripts.Input;
using _Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoCache
    {
        private GravityHandler _gravityHandler;
        private JumpHandler _jumpHandler;
        private CharacterController _controller;

        private float _speed;
        private float _dashDistance;

        private Vector3 _moveDirection;

        [Inject]
        public void Init(PlayerConfig config, GravityHandler gravityHandler, JumpHandler jumpHandler)
        {
            _speed = config.GetSpeed();
            _gravityHandler = gravityHandler;
            _jumpHandler = new JumpHandler(config.GetJumpTime(),config.GetJumpHeight(), gravityHandler);
            _controller = GetComponent<CharacterController>();
        }

        public void Move() =>  _controller.Move(_moveDirection * _speed);
        public void Dash() => _controller.Move(_moveDirection * _dashDistance);
        public void Jump() => _controller.Move(_jumpHandler.HandleJump(_moveDirection));


        public void UpdateDirection(Vector2 vct)
        {
            var vector = new Vector3 { x = vct.x, y = 0, z = vct.y };
            _moveDirection = _gravityHandler.ApplyGravity(vector) * Time.deltaTime;
        }
    }
}