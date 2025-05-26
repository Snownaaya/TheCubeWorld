using Assets.Scripts.UI;
using UnityEngine;
using YG;

namespace Assets.Scripts.PluginYG
{
    public class RewardedVideoAds : MonoBehaviour
    {
        [SerializeField] UIAutoHide _auitoHide;

        private int _advertisingId = 0;

        private void OnEnable()
        {
            YG2.onRewardAdv += OnShowAdv;
            YG2.onErrorAnyAdv += OnErrorVideoEvent;
        }

        private void OnDisable()
        {
            YG2.onRewardAdv -= OnShowAdv;
            YG2.onErrorAnyAdv -= OnErrorVideoEvent;
        }

        private void OnErrorVideoEvent()
        {

        }

        private void OnShowAdv(string id)
        {

        }
    }
}