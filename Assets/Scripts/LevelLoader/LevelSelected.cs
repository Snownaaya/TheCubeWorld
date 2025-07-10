using Random = UnityEngine.Random;
using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.LevelLoader
{
    [CreateAssetMenu(fileName = "LevelLoader", menuName = "LevelLoader/ScriptableObject", order = 0)]
    public class LevelSelected : ScriptableObject
    {
        private const string Level_1 = nameof(Level_1);
        private const string Level_2 = nameof(Level_2);
        private const string Level_3 = nameof(Level_3);

        [ReorderableList]
        [SerializeField] private string[] _levels = { Level_1, Level_2, Level_3 };

        private int _currentLevelIndex = 0;
        private bool _randomOrder = false;

        private void Awake() =>
            DontDestroyOnLoad(this);
        
        public string GetNextLevel()
        {
            if (_randomOrder)
                _currentLevelIndex = Random.Range(0, _levels.Length);
            else
                _currentLevelIndex = (_currentLevelIndex + 1) % _levels.Length;

            return _levels[_currentLevelIndex];
        }

        public string GetCurrentLevel()
        {
            if (_levels.Length == 0)
                return Level_1;

            return _levels[_currentLevelIndex];
        }
    }
}