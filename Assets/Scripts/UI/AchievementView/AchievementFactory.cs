﻿using Assets.Scripts.Achievements;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementFactory
    {
        private Dictionary<AchievementNames, Achievement> _achievements = new();

        public AchievementFactory(List<Achievement> achievements)
        {
            if (achievements == null)
                throw new ArgumentNullException(nameof(achievements));

            foreach (Achievement achievement in achievements)
            {
                if (achievement == null)
                {
                    Debug.LogWarning("Found null Achievement in list. Skipping.");
                    continue;
                }

                if (achievement.AchievementConfig == null)
                {
                    Debug.LogError($"Achievement is missing AchievementConfig! Name: {achievement.name} (Prefab: {achievement.gameObject.name})");
                    continue;
                }

                //if (_achievements.ContainsKey(achievement.AchievementConfig.AchievementNames))
                    _achievements.Add(achievement.AchievementConfig.AchievementNames, achievement);
            }
        }

        public Achievement Get(AchievementNames achievementNames, Transform parent)
        {
            if (_achievements.TryGetValue(achievementNames, out Achievement achievement))
                return UnityEngine.Object.Instantiate(achievement, parent);

            return null;
        }
    }
}