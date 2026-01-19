using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Player.Skins;
using Assets.Scripts.UI.Shop.SO;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements.Observers
{
    public class AchievemntBuyObserver
    {
        private HashSet<CharacterSkins> _buySkinsCounts = new();
        private HashSet<ObstacleTypes> _buyAbilityCounts = new();

        private int _maxSkinsBuyCount = 4;
        private int _maxAbilityBuyCount = 4;

        private Action<HashSet<ObstacleTypes>> _abilityBuyCheckers;
        private Action<HashSet<CharacterSkins>> _skinBuyCheckers;

        public AchievemntBuyObserver(Action<HashSet<ObstacleTypes>> abilities)
        {
            _abilityBuyCheckers = abilities;
        }

        public void OnSkinBuy(CharacterSkins skinType)
        {
            _buySkinsCounts.Add(skinType);

            if (_buySkinsCounts.Count >= _maxSkinsBuyCount)
                _buySkinsCounts.Remove(skinType);

            _skinBuyCheckers(_buySkinsCounts);
        }

        public void OnAbilityBuy(AbilityItem abilityType)
        {
            _buyAbilityCounts.Add(abilityType.AbilityTypes);

            _abilityBuyCheckers(_buyAbilityCounts);
        }
    }
}