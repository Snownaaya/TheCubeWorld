using Assets.Project.Scripts.Ground.Filler;
using Assets.Scripts.Camera;
using Assets.Scripts.Datas.Character;
using Assets.Scripts.GameStateMachine;
using Assets.Scripts.Ground;
using Assets.Scripts.Ground.Filler;
using Assets.Scripts.Interfaces;
using Cinemachine;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private FinalPlatform _finalPlatform;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private LevelFiller _levelFiller;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindSwitcher(containerBuilder);
            BindFinalPlatform(containerBuilder);
            BindVirtualCamera(containerBuilder);
            BindTransientData(containerBuilder);
            BindLevelFiller(containerBuilder);
        }

        private void BindSwitcher(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new GameState(), typeof(ISwitcher));

        private void BindFinalPlatform(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(_finalPlatform);

        private void BindVirtualCamera(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CinemachineTargetBinder(_cinemachineVirtualCamera),
                typeof(IVirtualCamera));

        private void BindTransientData(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new TransientCharacterData(), typeof(ITransientCharacterData));

        private void BindLevelFiller(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new LevelHazard(_levelFiller));
    }
}