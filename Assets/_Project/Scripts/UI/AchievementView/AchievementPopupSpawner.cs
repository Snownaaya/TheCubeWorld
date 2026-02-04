using Assets.Scripts.Achievements;
using Assets.Scripts.Service.Audio;
using Reflex.Attributes;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementPopupSpawner : MonoBehaviour
    {
        [SerializeField] private List<Achievement> _achievements = new();
        [SerializeField] private RectTransform _popupParent;

        private AchievementService _achievementService;
        private AchievementFactory _achievementFactory;
        private ForegroundAudioService _audioService;

        private float _delay = 3f;

        [Inject]
        private void Construct(AchievementService achievementService,
            ForegroundAudioService audioService)
        {
            _audioService = audioService;
            _achievementService = achievementService;
        }

        private void Awake() =>
            _achievementFactory = new AchievementFactory(_achievements);

        private void OnEnable() =>
            _achievementService.AchievementNameEarned += OnShowAchievement;

        private void OnDisable() =>
            _achievementService.AchievementNameEarned -= OnShowAchievement;

        private void OnShowAchievement(AchievementNames achievementNames)
        {
            Achievement achievement = _achievementFactory.Get(achievementNames, _popupParent);
            achievement.Show();

            _audioService.PlaySound(AudioTypes.PopupAchieve);

            DelayHide(achievement).Forget();
        }

        private async UniTask DelayHide(Achievement achievement)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
            achievement.Hide();
        }
    }
}