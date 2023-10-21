using System;
using _Scripts.Configs;
using _Scripts.Input;
using _Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoCache, IMovable
    {
        [SerializeField] private InputHandler inputHandler;
        private GravityHandler _gravityHandler;
        private JumpHandler _jumpHandler;
        private CharacterController _controller;

        private float _speed = 5;
        private Vector3 _moveDirection;

        [Inject]
        private void Init(InputHandler input, GravityHandler gravity, JumpHandler jump, PlayerConfig config)
        {
            _speed = config.GetSpeed();
            inputHandler = input;
            _gravityHandler = gravity;
            _jumpHandler = jump;
        }

        private void OnEnable() => inputHandler.JumpPerformed += Jump;
        private void OnDisable() => inputHandler.JumpPerformed -= Jump;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        protected override void OnTick()
        {
            _moveDirection = inputHandler.GetInputDirection();
            _gravityHandler.ApplyGravity(_moveDirection);
            Move(_moveDirection);
        }

        public void Move(Vector3 direction) => _controller.Move(direction * (_speed * Time.deltaTime));
        private void Jump() =>  _moveDirection = _jumpHandler.HandleJump(_moveDirection);
    }
}