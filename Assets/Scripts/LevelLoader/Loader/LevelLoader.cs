using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.LevelLoader.Loader
{
    internal abstract class LevelLoader : ILevelLoader
    {
        public void Load(LevelLoadingData levelLoadingData)
        {
            throw new NotImplementedException();
        }
    }
}
