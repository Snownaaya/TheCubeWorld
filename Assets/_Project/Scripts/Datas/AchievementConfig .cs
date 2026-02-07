using Assets.Scripts.Achievements;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Datas
{
    [CreateAssetMenu(fileName = "AchievementConfig", menuName = "Achievement/ScriptableObject")]
    public class AchievementConfig : ScriptableObject
    {
        [SerializeField] private AchievementNames _achievementNames;
        [SerializeField] private AssetReferenceGameObject _achievementPrefab;

        public AchievementNames AchievementNames => _achievementNames;

        public AssetReferenceGameObject AchievementPrefab => _achievementPrefab;
    }
}