using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.UI.HealthCharacters.Characters;
using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Service.Saves;
using Assets.Scripts.Player.Core;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class ServiceInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindSavesService(containerBuilder);
            BindPlayerSpawnService(containerBuilder);
            BindLevelLoader(containerBuilder);
            BindBridgeTracker(containerBuilder);
            BindDeathTracker(containerBuilder);
            BindPauseHandler(containerBuilder);
        }

        private void BindPlayerSpawnService(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ICharacterTeleportService>(container =>
            {
                CharacterHolder player = container.Resolve<CharacterHolder>();
                IStartLevel startLevel = container.Resolve<IStartLevel>();
                return new CharacterTeleportService(player, startLevel);
            });
        }

        private void BindLevelLoader(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new LevelLoader(), typeof(ILevelLoader));

        private void BindPauseHandler(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new PauseHandler(), typeof(PauseHandler));

        private void BindSavesService(ContainerBuilder containerBuilder)
        {
            SaveServiceFactory saveServiceFactory = new SaveServiceFactory();

            containerBuilder.AddSingleton(container => saveServiceFactory.CreateSaveService());
            containerBuilder.AddSingleton(container => saveServiceFactory.CreateJsonService());
        }

        private void BindBridgeTracker(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<BridgeTrackerService>(container =>
            {
                AchievementBridgeObserver achievementBridgeObserver = container.Resolve<AchievementBridgeObserver>();
                return new BridgeTrackerService(achievementBridgeObserver);
            });
        }

        private void BindDeathTracker(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<DeathTrackerService>(container =>
            {
                AchievementDeathObserver achievementDeathObserver = container.Resolve<AchievementDeathObserver>();
                return new DeathTrackerService(achievementDeathObserver);
            });
        }
    }
}