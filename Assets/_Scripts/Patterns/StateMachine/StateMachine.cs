using System.Collections.Generic;
using System.Linq;
using _Scripts.StateMachine.States;

namespace _Scripts.StateMachine
{
    public class StateMachine : IStateSwitcher
    {
        private List<IPersonalState> _states;
        private IPersonalState _currentStateElement;

        public StateMachine()
        {
            _states = new List<IPersonalState>()
            {

            };
            _currentStateElement = _states[0];
            _currentStateElement.Enter();
        }

        public void SwitchState<T>() where T : IPersonalState
        {
            var state = _states.FirstOrDefault(state => state is T);
            
            _currentStateElement.Exit();
            _currentStateElement = state;
            _currentStateElement?.Enter();
        }
    }
}