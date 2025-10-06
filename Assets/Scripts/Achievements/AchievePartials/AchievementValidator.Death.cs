using System.Collections.Generic;
using System;

namespace Assets.Scripts.Achievements.AchievePartials
{
    public partial class AchievementValidator
    {
        private Action<List<int>> DeathChecker(int deathCount, Action writeAchieve)
        {
            return deaths =>
            {
                if (deaths.Count >= deathCount)
                    writeAchieve();
            };
        }

        public List<Action<List<int>>> GetDeathValidators()
        {
            return new List<Action<List<int>>>
            {
                DeathChecker
                (
                   deathCount: 5,
                   writeAchieve: () => _achievementService.Achieve(AchievementNames.AnnoyingSetback)
                ),
                DeathChecker
                (
                   deathCount: 10,
                   writeAchieve: () =>_achievementService.Achieve(AchievementNames.SkillIssue)
                )
            };
        }
    }
}