using _Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private WeaponHolder weaponHolder;
        [SerializeField] private Movement movement;
        [SerializeField] private Vision vision;

        private PlayerInput _input;
        
        public void Awake()
        {
            _input = new PlayerInput();
            
            if(movement == null)
                movement = GetComponent<Movement>();
            
            if(vision == null)
                vision = FindObjectOfType(typeof(Vision)).GetComponent<Vision>();
            
            if(weaponHolder == null)
                weaponHolder = FindObjectOfType(typeof(WeaponHolder)).GetComponent<WeaponHolder>();
        }

        private void Update()
        {
            var moveVector = _input.Player.Move.ReadValue<Vector2>();
            var lookVector = _input.Player.Look.ReadValue<Vector2>();
            var scroll = _input.Player.SwitchWeapon.ReadValue<float>();
            
            movement.UpdateDirection(moveVector);
            movement.TryMove();

            if (lookVector != Vector2.zero)
            {
                vision.Look(lookVector);
            }

            if (_input.Player.Dash.phase == InputActionPhase.Performed)
            {
                movement.TryDash();
            }
            
            if (_input.Player.Jump.phase == InputActionPhase.Performed)
            {
                movement.TryJump();
            }
            
            switch (scroll)
            {
                case < 0: weaponHolder.TakePreviousWeapon();
                    break;
                case > 0: weaponHolder.TakeNextWeapon();
                    break;
            }
            
            if (_input.Player.Shoot.phase == InputActionPhase.Performed)
            {
                weaponHolder.PerformShoot();
            }
        }

        private void OnEnable() => _input.Enable();
        private void OnDisable() => _input.Disable();
    }
}