using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Enemies.Boss;
using Assets.Scripts.Particles;
using Assets.Scripts.Input;
using Assets.Scripts.Items;
using Reflex.Core;
using UnityEngine;
using Assets.Scripts.Service.ReflexService;

namespace Assets.Scripts.Game
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private ResourceSpawner _resourceSpawnerPrefab;
        [SerializeField] private ParticleSpawner _particleSpawner;
        [SerializeField] private JoystickInput _joystickInput;
        [SerializeField] private StartLevel _startLevelPrefab;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindCurrentBoss(containerBuilder);
            BindResourceSpawner(containerBuilder);
            InitParticle(containerBuilder);
            BindJoystick(containerBuilder);
            InitStartLevel(containerBuilder);
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
            //DontDestroyOnLoad(startLevel);

            containerBuilder.AddSingleton(startLevel, typeof(IStartLevel));
        }
    }
}
