using Random = UnityEngine.Random;
using UnityEngine;

namespace Assets.Scripts.LevelLoader
{
    public class LevelPool : PoolObject<Level>
    {
        [SerializeField] private Level[] _levels;

        private int _currentIndex = 0;
        private Level _currentLevel = null;

        public void SpawnLevel()
        {
            int prefabIndex = Random.Range(0, _levels.Length);
            Level levelPrefab = _levels[_currentIndex];

            Level level = Pull(levelPrefab);
            StartLevel startLevel = level.GetComponentInChildren<StartLevel>();

            startLevel.transform.position = level.transform.position;
            level.gameObject.SetActive(true);
        }

        public void ReturnLevel(Level level) =>
            Push(level);
    }
}