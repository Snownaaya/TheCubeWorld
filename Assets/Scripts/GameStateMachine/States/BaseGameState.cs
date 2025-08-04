using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class BaseGameState : IStates
    {
        private ISwitcher _switcher;
        private EntryPoint _flow;

        public BaseGameState(ISwitcher switcher, EntryPoint flow)
        {
            _switcher = switcher;
            _flow = flow;
        }

        public EntryPoint GameFlow => _flow;
        public ISwitcher Switcher => _switcher;

        public virtual void Enter()
        {
            Debug.Log($"{GetType()}");
        }

        public virtual void Exit() { }
    }
}
