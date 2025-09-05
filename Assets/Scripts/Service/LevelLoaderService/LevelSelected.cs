using Random = UnityEngine.Random;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Service.LevelLoaderService
{
    public class LevelSelected : MonoBehaviour
    {
        private const string Level_1 = nameof(Level_1);
        private const string Level_2 = nameof(Level_2);
        private const string Level_3 = nameof(Level_3);

        [ReorderableList]
        [SerializeField] private List<string> _levels;

        private string _currentLevel;

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
            if (_levels.Count == 0)
                return null;

            List<string> availableLevels = new List<string>();

            availableLevels.Remove(_currentLevel);

            if (availableLevels.Count == 0)
                availableLevels = new List<string>(_levels);

            int randomIndex = Random.Range(0, availableLevels.Count);
            return availableLevels[randomIndex];
        }

        public string GetCurrentLevel()
        {
            foreach (string level in _levels)
                return level;

            return null;
        }
    }
}