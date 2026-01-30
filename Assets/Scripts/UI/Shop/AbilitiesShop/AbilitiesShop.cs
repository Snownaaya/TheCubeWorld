using Assets.Scripts.Player.Wallet;
using Assets.Scripts.UI.Shop.Buttons;
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.AbilitiesShop
{
    public class AbilitiesShop : BaseShop
    {
        [SerializeField] private ShopPanel _shopPanel;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private OwnedImage _ownedImage;
        [SerializeField] private ShopContent _shopContent;

        private IWallet _wallet;
        private VisitorsHolder _visitorsHolder;
        private ShopItemView _currentItemView;

        public event Action<AbilityItem> AbilityItemClicked;

        [Inject]
        private void Construct(IWallet wallet)
        {
            _wallet = wallet;
            _walletView.Initialize(_wallet);
        }

        public override void Initialize(VisitorsHolder visitorsHolder, VisitorFactory visitorFactory)
        {
            _visitorsHolder = visitorsHolder;
            _shopPanel.Initialize(_visitorsHolder, visitorFactory);

            _shopPanel.ItemClickView(_shopContent.AbilityItems);

            _shopPanel.ItemViewClicked += OnItemViewClick;
        }

        private void OnEnable()
        {
            _buyButton.Clicked += OnBuyClicked;

            ShowBuyButton();
        }

        private void OnDisable() =>
            _buyButton.Clicked -= OnBuyClicked;

        protected override void OnBuyClicked()
        {
            if (_wallet.IsEnought(_currentItemView.Price))
            {
                if (_currentItemView.Item is AbilityItem abilityItem)
                {
                    AbilityItemClicked?.Invoke(abilityItem);
                }

                _currentItemView.Entry.Accept(_visitorsHolder.ContentUnlock);
                _currentItemView.Entry.Accept(_visitorsHolder.Purchase);

                _shopPanel.ItemClickView(_shopContent.AbilityItems);

                _currentItemView.Unlock();
                _wallet.RemoveCoins(_currentItemView.Price);

                ShowOnwedImage();
            }
            else
            {
                _currentItemView.Lock();
            }
        }

        protected override void OnItemViewClick(ShopItemView view)
        {
            _currentItemView = view;

            _currentItemView.Entry.Accept(_visitorsHolder.UnlockChecker);

            if (_visitorsHolder.UnlockChecker.IsUnlock)
            {
                _currentItemView.Entry.Accept(_visitorsHolder.PurchaseChecker);

                if (_visitorsHolder.PurchaseChecker.IsOwned)
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

        protected override void ShowBuyButton()
        {
            _buyButton.Show();
            _ownedImage.Hide();
        }

        public void ShowOnwedImage() =>
            _ownedImage.Show();
    }
}