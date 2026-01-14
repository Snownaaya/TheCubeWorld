using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public abstract class BaseGameState : IStates
    {
        private EntryPointState _entryPoint;
        private ISwitcher _switcher;

        public BaseGameState(
            ISwitcher switcher,
            EntryPointState entryPoint)
        {
            _switcher = switcher;
            _entryPoint = entryPoint;
        }

        public EntryPointState EntryPoint => _entryPoint;
        public ISwitcher Switcher => _switcher;

        public virtual void Enter() =>
            Debug.Log($"{GetType()}");

        public virtual void Exit() { }
    }
}