using Random = UnityEngine.Random;
using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.LevelLoader
{
    public class LevelSelected : MonoBehaviour
    {
        private const string Level_1 = nameof(Level_1);
        private const string Level_2 = nameof(Level_2);
        private const string Level_3 = nameof(Level_3);

        [ReorderableList]
        [SerializeField] private List<string> _levels;

        private int _currentLevelIndex = 0;
        private bool _randomOrder = false;

        private void Awake()
        {
            _levels = new List<string>()
            {
                Level_1,
                Level_2,
                Level_3,
            };
        }


        public string GetNextLevel()
        {
            if (_randomOrder)
                _currentLevelIndex = Random.Range(0, _levels.Count);
            else
                _currentLevelIndex = (_currentLevelIndex + 1) % _levels.Count;

            return _levels[_currentLevelIndex];
        }

        public string GetCurrentLevel()
        {
            var selectedLevel = _levels.FirstOrDefault();
            return selectedLevel;
        }
    }
}