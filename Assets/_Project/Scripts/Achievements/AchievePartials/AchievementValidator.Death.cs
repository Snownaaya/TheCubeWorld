using System.Collections.Generic;
using System;

namespace Assets.Scripts.Achievements.AchievePartials
{
    public partial class AchievementValidator
    {
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

        private Action<List<int>> DeathChecker(int deathCount, Action writeAchieve)
        {
            return deaths =>
            {
                foreach (int death  in deaths)
                {
                    if (--deathCount == 1)
                    {
                        writeAchieve();
                        return;
                    }
                }
            };
        }

    }
}