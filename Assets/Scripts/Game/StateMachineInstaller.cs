using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Interfaces;
using Reflex.Core;
using UnityEngine;

public class StateMachineInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private EntryPointState _gameFlow;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindSwitcher(containerBuilder);
    }

    private void BindSwitcher(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(new GameState(_gameFlow), typeof(ISwitcher));
    }
}