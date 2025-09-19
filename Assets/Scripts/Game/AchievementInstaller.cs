using Assets.Scripts.Achievements;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.Saves;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class AchievementInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindAchievementRepository(containerBuilder);
            BindAchievementService(containerBuilder);
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
    }
}