﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements
{
    public class AchievementService
    {
        private readonly Dictionary<AchievementNames, bool> _achievementsStatuses;
        private readonly AchievementDataRepository _dataProvider;

        public AchievementService(AchievementDataRepository dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException("AchievementDataRepository -> null");

            _achievementsStatuses = _dataProvider.GetAchievements();

            foreach (AchievementNames achievement in (AchievementNames[])Enum.GetValues(typeof(AchievementNames)))
                if (_achievementsStatuses.TryGetValue(achievement, out _) == false)
                    _achievementsStatuses.Add(achievement, false);

            RecordAchievements();
        }

        public IReadOnlyDictionary<AchievementNames, bool> AchievementsStatuses;

        public void RecordAchievements()
        {
            _dataProvider.SetAchievements(_achievementsStatuses);
        }

        public bool Achieve(AchievementNames achievementName)
        {
            if (_achievementsStatuses.ContainsKey(achievementName) && _achievementsStatuses[achievementName] == false)
            {
                _achievementsStatuses[achievementName] = true;
                RecordAchievements();
                return true;
            }

            return false;
        }
    }
}