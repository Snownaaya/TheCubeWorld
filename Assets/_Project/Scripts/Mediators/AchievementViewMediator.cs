namespace Assets.Scripts.Domain
{
    using System.Collections.Generic;
    using Assets.Scripts.Achievements;
    using Assets.Scripts.UI.AchievementView;
    using Reflex.Attributes;
    using UnityEngine;

    public class AchievementViewMediator : MonoBehaviour
    {
        [SerializeField] private List<AchievementView> _achieveView;

        private AchievementService _achievementService;

        [Inject]
        private void Construct(AchievementService achievementService) =>
            _achievementService = achievementService;

        private void OnEnable()
        {
            if (_achievementService != null)
                _achievementService.AchievementNameEarned += OnAchieveUnlocked;

            InitializeView();
        }

        private void OnDisable()
        {
            if(_achievementService != null)
            _achievementService.AchievementNameEarned -= OnAchieveUnlocked;
        }

        private void OnAchieveUnlocked(AchievementNames achievementNames)
        {
            foreach (AchievementView achievementView in _achieveView)
            {
                if (achievementView.AchievementConfig.AchievementNames == achievementNames)
                    achievementView.Unlock();
            }
        }

        private void InitializeView()
        {
            IReadOnlyDictionary<AchievementNames, bool> statuses = _achievementService.AchievementsStatuses;

            foreach (AchievementView view in _achieveView)
            {
                if (statuses.TryGetValue(view.AchievementConfig.AchievementNames, out bool unlock))
                {
                    if (unlock)
                        view.Unlock();
                    else
                        view.Lock();
                }
            }
        }
    }
}