using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Service.LevelLoaderService.Loader
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation Load(SceneID sceneID) =>
            SceneManager.LoadSceneAsync(sceneID.ToString(), LoadSceneMode.Single);
    }
}