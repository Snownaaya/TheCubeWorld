using Assets.Scripts.LevelLoader.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    internal interface ILevelLoader
    {
        void Load(LevelLoadingData levelLoadingData);
    }
}
