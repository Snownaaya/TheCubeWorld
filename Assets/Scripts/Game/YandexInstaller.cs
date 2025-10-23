﻿using Assets.Scripts.PluginYG;
using Reflex.Core;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class YandexInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private RewardedVideoAds _rewarded;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindRewardAds(containerBuilder);
        }

        private void BindRewardAds(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(containerBuilder => _rewarded);
        }
    }
}