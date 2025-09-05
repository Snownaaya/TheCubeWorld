using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Enemies.Boss;
using Assets.Scripts.Particles;
using Assets.Scripts.Input;
using Assets.Scripts.Items;
using Reflex.Core;
using UnityEngine;


namespace Assets.Scripts.Game
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private ResourceSpawner _resourceSpawnerPrefab;
        [SerializeField] private ParticleSpawner _particleSpawner;
        [SerializeField] private JoystickInput _joystickInput;
        [SerializeField] private StartLevel _startLevelPrefab;
        [SerializeField] private ResourceStorage _resourceStorage;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            InitStartLevel(containerBuilder);
            BindJoystick(containerBuilder);
            BindResourceSpawner(containerBuilder);
            BindResourceStorage(containerBuilder);
            InitParticle(containerBuilder);
            BindCurrentBoss(containerBuilder);
        }

        private void BindCurrentBoss(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CurrentBossService(), typeof(IBossTargetService));

        private void BindResourceSpawner(ContainerBuilder containerBuilder)
        {
            if (containerBuilder.HasBinding(typeof(IResourceService)) == false)
            {
                ResourceSpawner spawnPrefab = Instantiate(_resourceSpawnerPrefab);
                DontDestroyOnLoad(spawnPrefab);
                containerBuilder.AddSingleton(spawnPrefab, typeof(IResourceService));
            }
        }

        private void InitParticle(ContainerBuilder containerBuilder)
        {
            ParticleSpawner particlSystem = Instantiate(_particleSpawner);
            DontDestroyOnLoad(particlSystem);

            containerBuilder.AddSingleton(particlSystem, typeof(IParticleSpawner)); 
        }

        private void BindJoystick(ContainerBuilder containerBuilder)
        {
            JoystickInput joystickInput = Instantiate(_joystickInput);
            DontDestroyOnLoad(joystickInput);

            containerBuilder.AddSingleton(joystickInput, typeof(IJoystickInput));
        }

        private void InitStartLevel(ContainerBuilder containerBuilder)
        {
            StartLevel startLevel = Instantiate(_startLevelPrefab);
            DontDestroyOnLoad(startLevel);

            containerBuilder.AddSingleton(startLevel, typeof(IStartLevel));
        }

        private void BindResourceStorage(ContainerBuilder containerBuilder)
        {
            ResourceStorage resourceStorage = Instantiate(_resourceStorage);
            DontDestroyOnLoad(resourceStorage);

            containerBuilder.AddSingleton(resourceStorage, typeof(IResourceStorage));
        }
    }
}