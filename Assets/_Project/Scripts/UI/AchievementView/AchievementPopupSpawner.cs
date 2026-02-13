using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Achievements;
using Assets.Scripts.Datas;
using Assets.Scripts.Service.Audio;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementPopupSpawner : MonoBehaviour
    {
        [SerializeField] private RectTransform _popupParent;
        [SerializeField] private List<AchievementConfig> _achievemntConfigs;

        private AchievementService _achievementService;
        private AchievementFactory _achievementFactory;
        private ForegroundAudioService _audioService;

        private float _delay = 3f;

        [Inject]
        private void Construct(
            AchievementService achievementService,
            ForegroundAudioService audioService)
        {
            _audioService = audioService;
            _achievementService = achievementService;
        }

        private void Awake() =>
            _achievementFactory = new AchievementFactory();

        private void OnEnable() =>
            _achievementService.AchievementNameEarned += OnShowAchievement;

        private void OnDisable() =>
            _achievementService.AchievementNameEarned -= OnShowAchievement;

        private void OnShowAchievement(AchievementNames achievementNames)
        {
            AchievementConfig achievement = _achievemntConfigs.FirstOrDefault(achievement => achievement.AchievementNames == achievementNames);

            _audioService.PlaySound(AudioTypes.PopupAchieve);

            DelayHide(achievement)
                .Forget();
        }

        private async UniTask DelayHide(AchievementConfig achievementConfig)
        {
            Achievement achievement = await _achievementFactory.GetAsync(achievementConfig, _popupParent);

            achievement.Show();

            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            achievement.Hide();

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
        }
    }
}