using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _Scripts.Input
{
    public class InputHandler : MonoCache
    {
        public Action JumpPerformed;
        
        private PlayerInput _input;
        private Vector2 _inputVector;

        public InputHandler() => _input = new PlayerInput();

        protected override void OnTick()
        {
            var vector = _input.Player.Move.ReadValue<Vector2>();
            
            if(true)
                JumpPerformed?.Invoke();
        }

        public Vector3 GetInputDirection() => new Vector3() { x = _inputVector.x, y = 0, z = _inputVector.y };
    }
}