namespace Assets.Scripts.Installers
{
    using Assets._Project.Scripts.Items;
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Project.Scripts.Mediators.LevelCompletedMediator;
    using Assets.Scripts.Camera;
    using Assets.Scripts.Datas.Character;
    using Assets.Scripts.GameStateMachine;
    using Assets.Scripts.Ground;
    using Assets.Scripts.Ground.Filler;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Mediators.LevelCompletedMediator;
    using Assets.Scripts.Particles;
    using Cinemachine;
    using Reflex.Core;
    using UnityEngine;

    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private FinalPlatform _finalPlatform;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private LevelFiller _levelFiller;
        [SerializeField] private WinLevelWindowMediator _windowMediator;
        [SerializeField] private ResourceSpawner _resourceSpawner;
        [SerializeField] private ParticleSpawner _particleSpawner;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindSwitcher(containerBuilder);
            BindFinalPlatform(containerBuilder);
            BindVirtualCamera(containerBuilder);
            InitSpawner(containerBuilder);
            BindTransientData(containerBuilder);
            BindLevelFiller(containerBuilder);
            BindWinLevel(containerBuilder);
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
            containerBuilder.AddTransient(container =>
            {
                return new LevelHazard(_levelFiller);
            });

        private void BindWinLevel(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new WinLevelHandler(_windowMediator));

        private void InitSpawner(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IResourceService>(container =>
            {
                return _resourceSpawner;
            });

            containerBuilder.AddSingleton<IParticleSpawner>(container =>
            {
                return _particleSpawner;
            });
        }
    }
}