using UnityEngine;
using TMPro;

namespace Assets.Scripts.Player.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI balanceText;

        private IWallet _wallet;

        public void Initialize(IWallet wallet)
        {
            _wallet = wallet;

            UpdateValue(_wallet.GetCurrentCoin());

            _wallet.CharacterData.Money.Changed += UpdateValue;
        }

        private void OnDestroy() =>
            _wallet.CharacterData.Money.Changed -= UpdateValue;

        private void UpdateValue(int value) =>
            balanceText.text = value.ToString();
    }
}