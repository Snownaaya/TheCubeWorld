using UnityEngine.SceneManagement;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.LevelLoader.Loader
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation Load(string sceneName) =>
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}