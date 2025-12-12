using Assets.Scripts.Datas.Character;
using Assets.Scripts.Enemies.Boss.Target;
using Assets.Scripts.Input;
using Assets.Scripts.Items;
using Assets.Scripts.Other;
using Assets.Scripts.Particles;
using Assets.Scripts.Player.Saves;
using Assets.Scripts.Service.LevelLoaderService;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
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
            InitSpawner(containerBuilder);
            BindPersistentData(containerBuilder);
            BindCurrentBoss(containerBuilder);
        }

        private void BindCurrentBoss(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new CurrentBossService(), typeof(IBossTargetService));

        private void InitSpawner(ContainerBuilder containerBuilder)
        {
            SpawnerRoot spawnerRoot = Instantiate(_spawnerRoot);
            DontDestroyOnLoad(spawnerRoot);

            containerBuilder.AddSingleton(spawnerRoot.GetComponent<ResourceSpawner>(), typeof(IResourceService));
            containerBuilder.AddSingleton(spawnerRoot.GetComponent<ParticleSpawner>(), typeof(IParticleSpawner));
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

        private void BindPersistentData(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IPersistentCharacterData>(container =>
            {
                ICharacterSaveRepository characterSaveRepository = container.Resolve<ICharacterSaveRepository>();
                return new PersistentCharacterData(characterSaveRepository);
            });
        }
    }
}