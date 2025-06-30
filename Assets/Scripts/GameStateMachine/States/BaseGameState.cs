using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class BaseGameState : IStates
    {
        private ISwitcher _switcher;
        private GameFlow _flow;

        public BaseGameState(ISwitcher switcher, GameFlow flow)
        {
            _switcher = switcher;
            _flow = flow;
        }

        public GameFlow GameFlow => _flow;
        public ISwitcher Switcher => _switcher;

        public virtual void Enter()
        {
            Debug.Log($"{GetType()}");
        }

        public virtual void Exit() { }
    }
}
