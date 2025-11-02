using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Enemies.Boss.Target;
using Assets.Scripts.Particles;
using Assets.Scripts.Input;
using Assets.Scripts.Items;
using Assets.Scripts.Other;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private JoystickInput _joystickInput;
        [SerializeField] private StartLevel _startLevelPrefab;
        [SerializeField] private SpawnerRoot _spawnerRoot;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindStartLevel(containerBuilder);
            BindJoystick(containerBuilder);
            InitiSpawner(containerBuilder);

            BindCurrentBoss(containerBuilder);
        }

        private void BindCurrentBoss(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CurrentBossService(), typeof(IBossTargetService));

        private void InitiSpawner(ContainerBuilder containerBuilder)
        {
            SpawnerRoot spawnerRoot = Instantiate(_spawnerRoot);
            DontDestroyOnLoad(spawnerRoot);

            containerBuilder.AddSingleton(spawnerRoot.GetComponent<ResourceSpawner>(), typeof(IResourceService));
            containerBuilder.AddSingleton(spawnerRoot.GetComponent<ParticleSpawner>(), typeof(IParticleSpawner));
            containerBuilder.AddSingleton(spawnerRoot.GetComponent<ResourceStorage>(), typeof(IResourceStorage));
        }

        private void BindJoystick(ContainerBuilder containerBuilder)
        {
            JoystickInput joystickInput = Instantiate(_joystickInput);
            DontDestroyOnLoad(joystickInput);

            containerBuilder.AddSingleton(joystickInput, typeof(IJoystickInput));
        }

        private void BindStartLevel(ContainerBuilder containerBuilder)
        {
            StartLevel startLevel = Instantiate(_startLevelPrefab);
            DontDestroyOnLoad(startLevel);

            containerBuilder.AddSingleton(startLevel, typeof(IStartLevel));
        }
    }
}