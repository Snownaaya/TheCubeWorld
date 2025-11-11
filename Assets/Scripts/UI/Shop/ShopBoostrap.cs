using Assets.Scripts.Player.Wallet;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopBoostrap : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;

        private IWallet _wallet;

        private void Awake()
        {
            InitializeWallet();
        }

        [Inject]
        private void Construct(IWallet wallet) =>
            _wallet = wallet;

        private void InitializeWallet() =>
            _walletView.Initialize(_wallet);
    }
}