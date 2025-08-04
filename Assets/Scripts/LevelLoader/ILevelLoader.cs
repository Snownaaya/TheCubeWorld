using UnityEngine;

namespace Assets.Scripts.LevelLoader
{
    public interface ILevelLoader
    {
        AsyncOperation Load(string name);
    }
}
