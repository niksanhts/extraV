using _Scripts.Player;
using _Scripts.StateMachine.States;

namespace _Scripts.StateMachine
{
    public class PlayerMovementState : IPersonalState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly Movement PlayerMovement;

        private StateMachineData _data;

        public PlayerMovementState(Movement playerMovement, IStateSwitcher stateSwitcher,
            StateMachineData data)
        {
            PlayerMovement = playerMovement;
            StateSwitcher = stateSwitcher;
            _data = data;
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}