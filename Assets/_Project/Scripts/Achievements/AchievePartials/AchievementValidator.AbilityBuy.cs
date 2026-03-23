namespace Assets.Scripts.Achievements.AchievePartials
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Enemies.Obstacles;

    public partial class AchievementValidator
    {
        public Action<HashSet<ObstacleTypes>> GetAbilityBuyValidators()
        {
            return BuyAbilityChecker
             (
                 4,
                 writeAchieve: () => _achievementService.Achieve(AchievementNames.RichPerson)
             );
        }

        private Action<HashSet<ObstacleTypes>> BuyAbilityChecker(int abilityBuyCount, Action writeAchieve)
        {
            return boughtAbilities =>
            {
                if (boughtAbilities.Count == abilityBuyCount)
                    writeAchieve();
            };
        }
    }
}