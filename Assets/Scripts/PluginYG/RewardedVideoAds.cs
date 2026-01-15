using Assets.Scripts.UI.FinishedUI;
using Assets.Scripts.UI.GameUI;
using UnityEngine;
using YG;

namespace Assets.Scripts.PluginYG
{
    public class RewardedVideoAds : MonoBehaviour, IRewarderVideoAds
    {
        [SerializeField] private UIAutoHide _auitoHide;
        [SerializeField] private LossScreen _screen;
        [SerializeField] private AdsCoinButton _adsCoinButton;

        [SerializeField] private string _advertisingId = "rewardedVideo";

        private void OnEnable()
        {
            _screen.RewardAdsRequested += OnShowAdv;
            _adsCoinButton.OnClicked += OnShowAdv;
            YG2.onErrorAnyAdv += OnErrorVideoEvent;
        }

        private void OnDisable()
        {
            _screen.RewardAdsRequested -= OnShowAdv;
            
            YG2.onErrorAnyAdv -= OnErrorVideoEvent;
        }

        public void OnErrorVideoEvent()
        {
            //YG2.onErrorRewardedAdv
            _auitoHide.gameObject.SetActive(true);
        }

        public void OnShowAdv() =>
            YG2.RewardedAdvShow(_advertisingId);
    }
}