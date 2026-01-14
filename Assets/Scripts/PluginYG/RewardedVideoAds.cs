using Assets.Scripts.UI.GameUI;
using Reflex.Attributes;
using UnityEngine;
using YG;

namespace Assets.Scripts.PluginYG
{
    public class RewardedVideoAds : MonoBehaviour
    {
        [SerializeField] UIAutoHide _auitoHide;
        [SerializeField] LossScreen _screen;

        [SerializeField] private string _advertisingId = "rewardedVideo";

        private void OnEnable()
        {
            _screen.RewardAdsRequested += OnShowAdv;
            YG2.onErrorAnyAdv += OnErrorVideoEvent;
        }

        private void OnDisable()
        {
            _screen.RewardAdsRequested -= OnShowAdv;
            YG2.onErrorAnyAdv -= OnErrorVideoEvent;
        }

        private void OnErrorVideoEvent()
        {
            //YG2.onErrorRewardedAdv
            _auitoHide.gameObject.SetActive(true);
        }

        private void OnShowAdv() =>
            YG2.RewardedAdvShow(_advertisingId);
    }
}