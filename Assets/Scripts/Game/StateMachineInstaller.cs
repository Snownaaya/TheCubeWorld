using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Interfaces;
using Reflex.Core;
using UnityEngine;

public class StateMachineInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        BindSwitcher(containerBuilder);
    }

    private void BindSwitcher(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(new GameState(), typeof(ISwitcher));
    }
}