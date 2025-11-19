using Assets.Scripts.Player.Wallet;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopPanel _shopPanel;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private OwnedImage _ownedImage;

        private IWallet _wallet;
        private ShopVisitors _shopVisitors;
        private ShopItemView _currentItemView;

        [Inject]
        private void Construct(IWallet wallet)
        {
            _wallet = wallet;
            _walletView.Initialize(_wallet);
        }

        public void Initialize(ShopVisitors shopVisitors)
        {
            _shopVisitors = shopVisitors;
            _shopPanel.Initialize(_shopVisitors);
            _shopPanel.ItemViewClicked += OnItemViewClick;
        }

        private void OnEnable()
        {
            _buyButton.Clicked += OnBuyClicked;
        }

        private void OnDisable()
        {
            _shopPanel.ItemViewClicked -= OnItemViewClick;
            _buyButton.Clicked -= OnBuyClicked;
        }

        private void OnBuyClicked()
        {
            if (_wallet.IsEnought(_currentItemView.Price))
            {
                _wallet.RemoveCoins(_currentItemView.Price);
                _currentItemView.Entry.Accept(_shopVisitors.ContentUnlock);
                _currentItemView.Entry.Accept(_shopVisitors.SkinSelector);
                _currentItemView.Unlock();

                ShowOnwedImage();
            }
        }

        private void OnItemViewClick(ShopItemView view)
        {
            _currentItemView = view;

            _currentItemView.Entry.Accept(_shopVisitors.UnlockChecker);

            if (_shopVisitors.UnlockChecker.IsUnlock)
            {
                _currentItemView.Entry.Accept(_shopVisitors.SelectionChecker);

                if (_shopVisitors.SelectionChecker.IsOwned)
                {
                    ShowOnwedImage();
                    _buyButton.Hide();
                }
            }
            else
            {
                ShowBuyButton();
            }
        }

        private void ShowBuyButton()
        {
            _buyButton.Show();
            _ownedImage.Hide();
        }

        public void ShowOnwedImage() =>
            _ownedImage.Show();
    }
}