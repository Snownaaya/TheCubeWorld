namespace Assets.Scripts.Achievements.Observers
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Enemies.Obstacles;
    using Assets.Scripts.Player.Skins;
    using Assets.Scripts.UI.Shop.SO;

    public class AchievemntBuyObserver
    {
        private HashSet<CharacterSkins> _buySkinsCounts = new ();
        private HashSet<ObstacleTypes> _buyAbilityCounts = new ();

        private Action<HashSet<ObstacleTypes>> _abilityBuyCheckers;
        private Action<HashSet<CharacterSkins>> _skinBuyCheckers;

        public AchievemntBuyObserver(
            Action<HashSet<ObstacleTypes>> abilities,
            Action<HashSet<CharacterSkins>> skinBuyCheckers)
        {
            _abilityBuyCheckers = abilities;
            _skinBuyCheckers = skinBuyCheckers;
        }

        public void OnSkinBuy(CharacterSkinsItem shopItem)
        {
            _buySkinsCounts.Add(shopItem.CharacterSkins);

            _skinBuyCheckers(_buySkinsCounts);
        }

        public void OnAbilityBuy(AbilityItem abilityType)
        {
            _buyAbilityCounts.Add(abilityType.AbilityTypes);

            _abilityBuyCheckers(_buyAbilityCounts);
        }
    }
}