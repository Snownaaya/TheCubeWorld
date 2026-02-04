using Assets.Scripts.Achievements.AchievePartials;
using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Datas;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.Service.Audio;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.GameMessage;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Service.Saves;
using Reflex.Core;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Installers
{
    public class ServiceInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private AudioConfig _audioConfig;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            BindPlayerSpawnService(containerBuilder);
            BindLevelLoader(containerBuilder);
            BindBridgeTracker(containerBuilder);
            BindDeathTracker(containerBuilder);
            BindPauseHandler(containerBuilder);
            InitForegroundAudioService(containerBuilder);
            InitBackgroundAudio(containerBuilder);
            BindMessageBroked(containerBuilder);
            BindSavesServices(containerBuilder);
            BindAbilitiesBuy(containerBuilder);
            BindSkinsBuy(containerBuilder);
        }

        private void BindMessageBroked(ContainerBuilder containerBuilder)
        {
            IMessageBroker messageBroker = new MessageBroker();

            containerBuilder.AddSingleton<GameMessageBus>(container =>
            {
                return new GameMessageBus(messageBroker);
            });
        }

        private void BindPlayerSpawnService(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ICharacterTeleportService>(container =>
            {
                ICharacterHolder player = container.Resolve<ICharacterHolder>();
                IStartLevel startLevel = container.Resolve<IStartLevel>();
                return new CharacterTeleportService(player, startLevel);
            });
        }

        private void BindLevelLoader(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new LevelLoader(), typeof(ILevelLoader));

        private void BindPauseHandler(ContainerBuilder containerBuilder) =>
            containerBuilder.AddSingleton(new PauseHandler());

        private void BindBridgeTracker(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IBridgeBuildTracker>(container =>
            {
                AchievementValidator achievementValidator = container.Resolve<AchievementValidator>();
                AchievementBridgeObserver achievementBridgeObserver = new AchievementBridgeObserver(achievementValidator.GetBridgeValidators());
                return new BridgeTrackerService(achievementBridgeObserver);
            });
        }

        private void BindDeathTracker(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ICharacterDeathTracker>(container =>
            {
                AchievementValidator achievementValidator = container.Resolve<AchievementValidator>();
                AchievementDeathObserver achievementDeathObserver = new AchievementDeathObserver(achievementValidator.GetDeathValidators());
                return new DeathTrackerService(achievementDeathObserver);
            });
        }

        private void BindAbilitiesBuy(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddTransient<IAbilitiesBuyTracker>(container =>
            {
                AchievemntBuyObserver achievemntBuyObserver = container.Resolve<AchievemntBuyObserver>();
                return new AbilitiesBuyTarckerService(achievemntBuyObserver);
            });
        }

        private void BindSkinsBuy(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<ISkinsBuyTracker>(container =>
            {
                AchievemntBuyObserver achievemntBuyObserver = container.Resolve<AchievemntBuyObserver>();
                return new SkinBuyTracker(achievemntBuyObserver);
            });
        }

        private void InitForegroundAudioService(ContainerBuilder containerBuilder)
        {
            Dictionary<AudioTypes, AudioData> audioData = new Dictionary<AudioTypes, AudioData>();

            foreach (var data in _audioConfig.AudioDatas)
                audioData[data.AudioTypes] = data;

            ForegroundAudioService audioService = new ForegroundAudioService(audioData);
            containerBuilder.AddSingleton(audioService);
        }

        private void InitBackgroundAudio(ContainerBuilder containerBuilder)
        {
            BackgroundAudioService backgroundAudioService = new BackgroundAudioService(_audioConfig.AudioDatas);

            backgroundAudioService.PlayBackground(AudioTypes.Background);
            containerBuilder.AddSingleton(backgroundAudioService);
        }

        private void BindSavesServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(new JsonService(), typeof(IJsonService));
            containerBuilder.AddSingleton(new SaveService(), typeof(ISaveService));
        }
    }
}