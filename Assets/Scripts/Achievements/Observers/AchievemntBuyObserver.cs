using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Player.Skins;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Achievements.Observers
{
    public class AchievemntBuyObserver
    {
        private HashSet<ObstacleTypes> _buySkinsCounts = new();
        private HashSet<CharacterSkins> _buyAbilityCounts = new();

        private int _maxSkinsBuyCount = 4;
        private int _maxAbilityBuyCount = 4;

        private IEnumerable<Action<HashSet<ObstacleTypes>>> _skinBuyCheckers;
        private IEnumerable<Action<HashSet<CharacterSkins>>> _abilityBuyCheckers;

        public AchievemntBuyObserver()
        {
            
        }

        public void OnSkinBuy(ObstacleTypes skinType)
        {
            _buySkinsCounts.Add(skinType);

            if (_buySkinsCounts.Count >= _maxSkinsBuyCount)
                _buySkinsCounts.Remove(skinType);

            foreach (Action<HashSet<ObstacleTypes>> skinCheck in _skinBuyCheckers)
                skinCheck(_buySkinsCounts);
        }

        public void OnAbilityBuy(CharacterSkins abilityType)
        {
            _buyAbilityCounts.Add(abilityType);

            if (_buyAbilityCounts.Count >= _maxAbilityBuyCount)
                _buyAbilityCounts.Remove(abilityType);

            foreach (Action<HashSet<CharacterSkins>> abilityCheck in _abilityBuyCheckers)
                abilityCheck(_buyAbilityCounts);
        }
    }
}