using Assets.Scripts.LevelLoader.Loader;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ILevelLoader
    {
        AsyncOperation Load(string name);
    }
}
