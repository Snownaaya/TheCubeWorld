using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Other
{
    public abstract class StateMachine<T> : ISwitcher where T : IStates
    {
        protected Dictionary<Type, T> _states;
        protected T _currentState;

        protected StateMachine()
        {
            _states = new Dictionary<Type, T>();
        }

        public void SwitchState<TState>() where TState : IStates
        {
            if (_states.TryGetValue(typeof(TState), out T states))
            {
                if (_states.GetType() == null && _currentState == null)
                    return;

                _currentState?.Exit();
                _currentState = states;
                _currentState?.Enter();
            }
        }
    }
}