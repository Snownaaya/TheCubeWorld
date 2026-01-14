using System;
using YG;

namespace Assets.Scripts.PluginYG
{
    public class YandexAdsService : IAdsService
    {
        private const string RewardedAdId = "rewardedVideo";

        public void ShowRewarded(Action onSuccess, Action onFail)
        {
            void OnReward(string _)
            {
                Cleanup();
                onSuccess?.Invoke();
            }

            void OnError()
            {
                Cleanup();
                onFail?.Invoke();
            }

            void Cleanup()
            {
                YG2.onRewardAdv -= OnReward;
                YG2.onErrorRewardedAdv -= OnError;
            }

            YG2.onRewardAdv += OnReward;
            YG2.onErrorRewardedAdv += OnError;

            YG2.RewardedAdvShow(RewardedAdId);
        }
    }
}