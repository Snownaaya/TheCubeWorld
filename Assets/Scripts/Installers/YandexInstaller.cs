using Assets.Scripts.PluginYG;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class YandexInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private RewardedVideoAds _rewarded;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindRewardAds(containerBuilder);
            BindAdsService(containerBuilder);
        }

        private void BindRewardAds(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(containerBuilder => _rewarded);

        private void BindAdsService(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new YandexAdsService(), typeof(IAdsService));
    }
}