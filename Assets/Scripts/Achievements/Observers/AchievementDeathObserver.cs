using Assets.Scripts.Player.Core;
using System.Collections.Generic;
using System;
using System.Linq;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Achievements.Observers
{
    public class AchievementDeathObserver
    {
        private List<int> _deaths = new();

        private int _deathCount = 0;
        private int _maxDeathCount = 10;

        private IEnumerable<Action<List<int>>> _deathCheck;

        public AchievementDeathObserver(IEnumerable<Action<List<int>>> deathCount) =>
            _deathCheck = deathCount;

        public void OnPlayerDeath(ILoss loss)
        {
            _deaths.Add(_deathCount++);

            var deathList = _deaths
                .Take(_maxDeathCount).ToList();

            foreach (var check in _deathCheck)
                check(deathList);
        }
    }
}