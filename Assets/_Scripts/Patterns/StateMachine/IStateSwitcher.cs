using _Scripts.StateMachine.States;

namespace _Scripts.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IPersonalState;
    }
}