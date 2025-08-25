using UnityEngine;

namespace Assets.Scripts.Service.LevelLoaderService.Loader
{
    public interface ILevelLoader
    {
        AsyncOperation Load(string name);
    }
}