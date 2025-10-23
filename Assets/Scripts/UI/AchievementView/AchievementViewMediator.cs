using Assets.Scripts.Achievements;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementViewMediator : MonoBehaviour
    {
        [SerializeField] private List<AchievementView> _achieveView;

        private AchievementService _achievementService;

        [Inject]
        private void Construct(AchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        private void OnEnable()
        {
            
        }
    }
}
