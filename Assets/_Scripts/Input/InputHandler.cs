using _Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Scripts.Input
{
    public class InputHandler : MonoCache
    {
        [SerializeField] private Movement _movement;

        private PlayerInput _input;
        private Vector2 _inputVector;

        [Inject]
        public void Init(PlayerInput input)
        {
            _input = input;
            _movement = GetComponent<Movement>();
        }

        protected override void OnTick()
        {
            var vector = _input.Player.Move.ReadValue<Vector2>();

            if (vector != Vector2.zero)
            {
                _movement.UpdateDirection(vector);
                _movement.Move();
            }

            if (_input.Player.Dash.phase == InputActionPhase.Performed)
            {
                _movement.Dash();
            }
            
            if (_input.Player.Jump.phase == InputActionPhase.Performed)
            {
                _movement.Jump();
            }
        }
    }
}