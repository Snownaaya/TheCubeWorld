using Assets.Scripts.Player.Core;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Assets.Scripts.Achievements.Observers
{
    public class AchievementDeathObserver
    {
        private CharacterHolder _characterHolder;

        private List<int> _deaths = new();

        private int _deathCount = 0;
        private int _maxDeathCount = 10;

        private IEnumerable<Action<List<int>>> _deathCheck;

        public AchievementDeathObserver(CharacterHolder characterHolder, IEnumerable<Action<List<int>>> deathCount)
        {
            _characterHolder = characterHolder;
            _deathCheck = deathCount;
        }

        public void PlayerDeath()
        {
            if (_characterHolder.Character.Health.IsDead == true)
            {
                _deaths.Add(++_deathCount);

                var deathList = _deaths
                    .Take(_maxDeathCount).ToList();

                foreach (var check in _deathCheck)
                    check(deathList);
            }
        }
    }
}