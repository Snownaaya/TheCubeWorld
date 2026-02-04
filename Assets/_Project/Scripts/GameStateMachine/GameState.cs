using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.GameStateMachine
{
    public class GameState : ISwitcher
    {
        private Dictionary<Type ,IStates> _states = new Dictionary<Type, IStates>();
        private IStates _currentState;

        public void Initialize(params IStates[] states)
        {
            Clear();

            foreach (var state in states)
                _states[state.GetType()] = state;

            _currentState = states.FirstOrDefault();
            _currentState?.Enter();
        }

        public void SwitchState<T>() where T : IStates
        {
            if (_states.TryGetValue(typeof(T), out IStates newState))
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState?.Enter();
            }
            else
            {
                throw new ArgumentException($"Состояние типа {typeof(T).Name} не найдено в словаре!");
            }
        }

        public void Clear()
        {
            _currentState?.Exit();
            _states.Clear();
            _currentState = null;
        }
    }
}