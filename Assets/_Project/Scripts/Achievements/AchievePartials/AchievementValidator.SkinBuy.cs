namespace Assets.Scripts.Achievements.AchievePartials
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Player.Skins;

    public partial class AchievementValidator
    {
        public Action<HashSet<CharacterSkins>> GetSkinBuyValidators()
        {
            return BuySkinChecker
             (
                3,
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