using System;

namespace Assets.Scripts.Interfaces
{
    public interface ILevelProgressMediator
    {
        public event Action PlayerReachedFinalPlatform;
    }
}
