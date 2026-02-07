using System;
using System.Collections.Generic;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Project.Scripts.Datas
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "SceneConfig/ScriptableObject")]
    public class SceneConfig : ScriptableObject
    {
        [field: SerializeField] public List<SceneMapping> SceneMappings { get; private set; }

        [Serializable]
        public struct SceneMapping
        {
            [SerializeField] private SceneID _sceneID;
            [SerializeField] private AssetReference _nextLevelScene;

            public SceneID SceneID => _sceneID;

            public AssetReference NextLevelScene => _nextLevelScene;
        }
    }
}