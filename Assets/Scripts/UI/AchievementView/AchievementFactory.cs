using Assets.Scripts.Achievements;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementFactory
    {
        private Dictionary<AchievementNames, Achievement> _achievements;

        public AchievementFactory(List<Achievement> achievements)
        {
            if (achievements == null)
                throw new ArgumentNullException(nameof(achievements));

            _achievements = new Dictionary<AchievementNames, Achievement>();

            foreach (var achievement in achievements)
            {
                if (achievement == null)
                    continue;

                if (_achievements.ContainsKey(achievement.AchievementConfig.AchievementNames))
                    continue;

                _achievements.Add(achievement.AchievementConfig.AchievementNames, achievement);
            }
        }

        public Achievement Get(AchievementNames achievementNames, Transform parent)
        {
            if(_achievements.TryGetValue(achievementNames, out Achievement achievement)) 
                return UnityEngine.Object.Instantiate(achievement, parent);


            return null;
        }
    }
}