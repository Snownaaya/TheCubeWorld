using Assets._Project.Scripts.AddressablesModule;
using Assets.Scripts.Achievements;
using Assets.Scripts.Datas;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.UI.AchievementView
{
    public class AchievementFactory
    {
        public async UniTask<Achievement> GetAsync(AchievementConfig achievementConfig, Transform parent)
        {
            if (achievementConfig.AchievementPrefab == null)
                return null;

            GameObject instance = await AddressableUtility.InstantiatePrefab(achievementConfig.AchievementPrefab, parent);

            if (instance.TryGetComponent(out Achievement achievement))
                return achievement;

            if (instance != null)
                Addressables.ReleaseInstance(instance);

            return null;
        }
    }
}