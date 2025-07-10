using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Interfaces;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class StateMachineInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameFlow _gameFlow;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new GameState(_gameFlow), typeof(ISwitcher));
        }
    }
}