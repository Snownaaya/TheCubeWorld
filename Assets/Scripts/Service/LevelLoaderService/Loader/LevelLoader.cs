using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Service.LevelLoaderService.Loader
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation Load(string sceneName) =>
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}