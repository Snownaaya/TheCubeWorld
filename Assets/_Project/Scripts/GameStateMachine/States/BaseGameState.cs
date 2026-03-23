namespace Assets.Scripts.GameStateMachine.States
{
    using Assets.Scripts.Interfaces;
    using UnityEngine;

    public abstract class BaseGameState : IStates
    {
        private ISwitcher _switcher;

        public BaseGameState(ISwitcher switcher) =>
            _switcher = switcher;

        public ISwitcher Switcher => _switcher;

        public virtual void Enter() =>
            Debug.Log($"{GetType()}");

        public virtual void Exit() { }
    }
}