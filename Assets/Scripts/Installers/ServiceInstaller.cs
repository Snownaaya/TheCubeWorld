using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Datas;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.Service.Audio;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.Json;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Service.Saves;
using Reflex.Core;
using System.Collections.Generic;
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
            BindSavesServices(containerBuilder);
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
            containerBuilder.AddSingleton(new PauseHandler());

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