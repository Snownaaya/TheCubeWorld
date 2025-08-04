using Assets.Scripts.GameStateMachine.States;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.GameStateMachine
{
    public class GameState : ISwitcher
    {
        private List<IStates> _states;
        private IStates _currentState;
        private EntryPoint _gameFlow;

        public GameState(EntryPoint gameFlow)
        {
            _gameFlow = gameFlow;

            _states = new List<IStates>
            {
                new StartLevelState(this, _gameFlow),
                new LossState(this, _gameFlow),
                new SettingsState(this, _gameFlow),
                new EndLevelState(this, _gameFlow),
                new RespawnState(this, _gameFlow)
            };
        }

        public void SwitchState<T>() where T : IStates
        {
            IStates state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}