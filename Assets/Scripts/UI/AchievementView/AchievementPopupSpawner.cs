using Assets.Scripts.Achievements;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementPopupSpawner : MonoBehaviour
    {
        [SerializeField] private List<Achievement> _achievements;
        [SerializeField] private RectTransform _popupParent;

        private AchievementService _achievementService;
        private AchievementFactory _achievementFactory;
        private Achievement _currentAchievementPopup;

        [Inject]
        private void Construct(AchievementService achievementService) =>
            _achievementService = achievementService;

        private void Awake() =>
            _achievementFactory = new AchievementFactory(_achievements);

        private void OnEnable() =>
            _achievementService.AchievementNameEarned += OnShowAchievement;

        private void OnDisable() =>
            _achievementService.AchievementNameEarned -= OnShowAchievement;

        private void OnShowAchievement(AchievementNames achievementNames)
        {
            if (_currentAchievementPopup != null)
                _currentAchievementPopup.Hide();

            Achievement achievement = _achievementFactory.Get(achievementNames, _popupParent);
            _currentAchievementPopup = achievement;
            _currentAchievementPopup.gameObject.SetActive(true);

            if (_currentAchievementPopup != null)
                _currentAchievementPopup.Show();
        }
    }
}