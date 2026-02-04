using Assets.Scripts.PluginYG;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class YandexInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindRewardAds(containerBuilder);
        }

        private void BindRewardAds(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(typeof(IRewarderVideoAds));
    }
}