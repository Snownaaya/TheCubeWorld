using Assets.Scripts.Interfaces;
using Assets.Scripts.UI.BridgeBuilder;
using System;
using System.Collections.Generic;

public class BuildBridgeState : ISwitcher
{
    private readonly Dictionary<Type, IStates> _stateDictiniory;

    private IStates _currentState;
    private BuildButton _buildButton;

    public BuildBridgeState(BuildButton buildButton)
    {
        _buildButton = buildButton;

        _stateDictiniory = new Dictionary<Type, IStates>
        {
            {typeof(DirtSelectedState), new DirtSelectedState(_buildButton)},
            {typeof(WoodSelectedState), new WoodSelectedState(_buildButton)},
            {typeof(StoneSelectedState), new StoneSelectedState(_buildButton)}
        };
    }

    public void SwitchState<T>() where T : IStates
    {
        if (_stateDictiniory.TryGetValue(typeof(T), out IStates states))
        {
            if (_stateDictiniory.GetType() == null && _currentState == null)
                return;

            _currentState?.Enter();
            _currentState = states;
            _currentState?.Exit();
        }
    }
}