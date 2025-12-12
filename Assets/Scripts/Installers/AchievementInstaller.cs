using Assets.Scripts.Achievements;
using Assets.Scripts.Achievements.AchievePartials;
using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.Saves;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class AchievementInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindAchievementRepository(containerBuilder);
            BindAchievementService(containerBuilder);
            BindAchievementValidator(containerBuilder);
            BindAchievementBridgeObserver(containerBuilder);
            BindAchievementDeathObserver(containerBuilder);
        }

        private void BindAchievementRepository(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<AchievementDataRepository>(container =>
            {
                IJsonService jsonService = container.Resolve<IJsonService>();
                ISaveService saveService = container.Resolve<ISaveService>();

                return new AchievementDataRepository(saveService, jsonService);
            });
        }

        private void BindAchievementService(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<AchievementService>(container =>
            {
                AchievementDataRepository achievementDataRepository = container.Resolve<AchievementDataRepository>();

                return new AchievementService(achievementDataRepository);
            });
        }

        private void BindAchievementValidator(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<AchievementValidator>(container =>
            {
                AchievementService achievementService = container.Resolve<AchievementService>();
                return new AchievementValidator(achievementService);
            });
        }

        private void BindAchievementBridgeObserver(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<AchievementBridgeObserver>(container =>
            {
                AchievementValidator achievementValidator = container.Resolve<AchievementValidator>();
                return new AchievementBridgeObserver(achievementValidator.GetBridgeValidators());
            });
        }

        private void BindAchievementDeathObserver(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<AchievementDeathObserver>(container =>
            {
                AchievementValidator achievementValidator = container.Resolve<AchievementValidator>();
                return new AchievementDeathObserver(achievementValidator.GetDeathValidators());
            });
        }
    }
}