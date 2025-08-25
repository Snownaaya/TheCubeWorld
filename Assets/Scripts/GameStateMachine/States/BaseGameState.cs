using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class BaseGameState : IStates
    {
        private EntryPointState _entryPoint;
        private ISwitcher _switcher;
        private ITransformable _player;

        public BaseGameState(ISwitcher switcher, EntryPointState entryPoint)
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