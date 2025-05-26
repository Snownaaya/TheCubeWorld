using Assets.Scripts.Other;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ServiceInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(PauseHandler));
        }
    }
}
