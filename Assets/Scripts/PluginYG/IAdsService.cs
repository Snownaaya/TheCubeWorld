using System;

namespace Assets.Scripts.PluginYG
{
    public interface IAdsService
    {
        public void ShowRewarded(Action onSuccess, Action onFail);
    }
}