using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Service.LevelLoaderService.Loader;

namespace Assets.Scripts.Service.LevelLoaderService
{
    public class LevelSelected : MonoBehaviour
    {
        [SerializeField] private List<SceneID> _levels;

        private SceneID _currentLevel;

        private void Awake()
        {
            _levels = new List<SceneID> 
            {
                SceneID.Level_1, 
                SceneID.Level_2,
                SceneID.Level_3 
            };
        }

        public SceneID GetNextLevel()
        {
            if (_levels.Count == 0)
                return _currentLevel;

            int randomIndex = Random.Range(0, _levels.Count);
            return _levels[randomIndex];
        }

        public SceneID GetCurrentLevel()
        {
            foreach (SceneID level in _levels)
                return level;

            throw new System.Exception("No levels available to select the current level.");
        }

        public SceneID GetMainMenu() =>
            SceneID.MainMenu;
    }
}