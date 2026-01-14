using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements.AchievePartials
{
    public partial class AchievementValidator
    {
        private Action<int> BuyChecker(int purchaseCount, Action writeAchieve/*, bool isCorrectBuy*/)
        {
            return purchases =>
            {
                if (purchases >= purchaseCount)
                {
                    writeAchieve();
                }
            };
        }

        public List<Action<int>> GetBuyValidators()
        {
            return new List<Action<int>>
            {
                BuyChecker
                (
                   purchaseCount: 4,
                   writeAchieve: () => _achievementService.Achieve(AchievementNames.Fashionista)
                ),
                BuyChecker
                (
                   purchaseCount: 4,
                   writeAchieve: () =>_achievementService.Achieve(AchievementNames.RichPerson)
                )
            };
        }
    }
}
