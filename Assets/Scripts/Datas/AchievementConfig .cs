using Assets.Scripts.Achievements;
using UnityEngine;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "AchievementConfig", menuName = "Achievement/ScriptableObject")]
    public class AchievementConfig : ScriptableObject
    {
        [SerializeField] private AchievementNames _achievementNames;
        [SerializeField] private Sprite _achievementIcon;

        public AchievementNames AchievementNames => _achievementNames;
        public Sprite AchievementIcon => _achievementIcon;
    }
}