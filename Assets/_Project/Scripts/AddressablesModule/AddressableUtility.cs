using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Assets._Project.Scripts.AddressablesModule
{
    public class AddressableUtility
    {
        public static async UniTask<T> Load<T>(AssetReference assetReference)
        {
            var handle = Addressables.LoadAssetAsync<T>(assetReference);

            return await handle.ToUniTask();
        }

        public static async UniTask<SceneInstance> LoadSceneAdditive(
             AssetReference assetReference,
             bool activateOnLoad = false)
        {
            var handle = Addressables.LoadSceneAsync(
                assetReference,
                LoadSceneMode.Additive,
                activateOnLoad
            );

            return await handle.ToUniTask();
        }

        public static async UniTask<GameObject> InstantiatePrefab(AssetReference assetReference, Transform transform)
        {
            var handle = Addressables.InstantiateAsync(assetReference, transform);

            GameObject instance = await handle.ToUniTask();

            return instance;
        }
    }
}
