using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Player.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI balanceText;
        [SerializeField] private RectTransform _rectTransform;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private IWallet _wallet;

        public void Initialize(IWallet wallet)
        {
            _wallet = wallet;

            UpdateValue(_wallet.GetCurrentCoin());

            _wallet.PersistentCharacterData.Money
                 .Subscribe(UpdateValue)
                 .AddTo(_compositeDisposable);
        }

        private void OnDestroy() =>
            _compositeDisposable.Dispose();

        private void UpdateValue(int value) =>
            balanceText.text = value.ToString();

        public void Show() =>
            _rectTransform.gameObject.SetActive(true);

        public void Hide() =>
            _rectTransform.gameObject.SetActive(false);
    }
}