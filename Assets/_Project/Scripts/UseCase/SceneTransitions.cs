using Assets._Project.Scripts.AddressablesModule;
using Assets.Project.Scripts.Datas;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Assets.Scripts.UseCase
{
    public class SceneTransitions
    {
        private SceneID _currentSceneID;
        private SceneInstance _currentScene;

        private SceneConfig _sceneConfig;

        private float _delay = 1.4f;
        private bool _isFirstLoad = true;

        private Dictionary<SceneID, AssetReference> _scenesMap = new Dictionary<SceneID, AssetReference>();

        public SceneTransitions(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;

            foreach (var mapping in _sceneConfig.SceneMappings)
                _scenesMap[mapping.SceneID] = mapping.NextLevelScene;
        }

        public async UniTask<SceneID> GetMainMenu()
        {
            await LoadLevel(SceneID.MainMenu);

            return SceneID.MainMenu;
        }

        public SceneID GetCurrentLevel() =>
             _currentSceneID;

        public async UniTask<SceneID> GetNextLevel()
        {
            var availableLevels = _scenesMap.Keys
                .Where(id => id != SceneID.MainMenu)
                .ToList();

            if (availableLevels.Count == 0)
                return SceneID.MainMenu;

            int randomIndex = Random.Range(0, availableLevels.Count);
            SceneID sceneID = availableLevels[randomIndex];

            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
            await LoadLevel(sceneID);

            return sceneID;
        }

        public async UniTask StartLevel(SceneID sceneID)
        {
            if (_scenesMap.ContainsKey(sceneID) == false)
                return;

            await LoadLevel(sceneID);
        }

        private async UniTask LoadLevel(SceneID sceneID)
        {
            if (_scenesMap.TryGetValue(sceneID, out var assetReference) == false)
                return;

            if (_isFirstLoad)
            {
                SceneInstance sceneInstance =
                    await Addressables.LoadSceneAsync(assetReference, LoadSceneMode.Single).ToUniTask();

                _currentScene = sceneInstance;
                _currentSceneID = sceneID;
                _isFirstLoad = false;
            }
            else
            {
                SceneInstance nextScene =
                    await AddressableUtility.LoadSceneAdditive(assetReference);

                await nextScene.ActivateAsync(); SceneManager.SetActiveScene(nextScene.Scene);

                if (_currentScene.Scene.IsValid())
                    await Addressables.UnloadSceneAsync(_currentScene)
                        .ToUniTask();

                _currentScene = nextScene;
                _currentSceneID = sceneID;
            }
        }
    }
}