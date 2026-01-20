using Assets.Scripts.Player.Skins;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements.AchievePartials
{
    public partial class AchievementValidator
    {
        public Action<HashSet<CharacterSkins>> GetSkinBuyValidators()
        {
            return BuySkinChecker
             (
                1,
                writeAchieve: () => _achievementService.Achieve(AchievementNames.Fashionista)
             );
        }

        private Action<HashSet<CharacterSkins>> BuySkinChecker(int skinBuyCount, Action writeAchieve)
        {
            return boughtSkins =>
            {
                if (boughtSkins == null)
                    return;

                if (boughtSkins.Count == skinBuyCount)
                    writeAchieve();
            };
        }
    }
}