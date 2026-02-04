using Assets.Scripts.Player.Wallet;
using Assets.Scripts.UI.Shop.AbilitiesShop;
using Assets.Scripts.UI.Shop.Buttons;
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.SkinsShop
{
    public class SkinsShop : BaseShop
    {
        [SerializeField] private SkinsShopPanel _panel;
        [SerializeField] private SelectionButton _selectionButton;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private ShopContent _shopContent;
        [SerializeField] private OwnedImage _ownedImage;

        private VisitorsHolder _visitorsHolder;
        private IWallet _wallet;
        private ShopItemView _currentItemView;

        public event Action<CharacterSkinsItem> CharacterSkinsItemClicked;

        public override void Initialize(
            VisitorsHolder visitorsHolder,
            VisitorFactory visitorFactory)
        {
            _visitorsHolder = visitorsHolder;
            _panel.Initialize(_visitorsHolder, visitorFactory);
            _walletView.Initialize(_wallet);

            _panel.Populate(_shopContent.CharacterSkinItem);

            _panel.ItemViewClicked += OnItemViewClick;
        }

        [Inject]
        private void Construct(IWallet wallet) =>
            _wallet = wallet;

        private void OnEnable()
        {
            _buyButton.Clicked += OnBuyClicked;
            _selectionButton.Clicked += OnSelectionButtonClick;
        }

        private void OnDisable()
        {
            _buyButton.Clicked -= OnBuyClicked;
            _selectionButton.Clicked -= OnSelectionButtonClick;
        }

        private void OnSelectionButtonClick()
        {
            if (_currentItemView == null)
                return;

            _currentItemView.Entry.Accept(_visitorsHolder.Purchase);

            _ownedImage.Show();
            _panel.Populate(_shopContent.CharacterSkinItem);
            _selectionButton.Hide();
        }

        protected override void OnBuyClicked()
        {
            if (_wallet.IsEnought(_currentItemView.Price))
            {
                if (_currentItemView.Item is CharacterSkinsItem characterSkinsItem)
                {
                    CharacterSkinsItemClicked?.Invoke(characterSkinsItem);
 
                }

                _currentItemView.Entry.Accept(_visitorsHolder.ContentUnlock);
                _currentItemView.Entry.Accept(_visitorsHolder.Purchase);

                _wallet.RemoveCoins(_currentItemView.Price);

                _panel.Populate(_shopContent.CharacterSkinItem);
                _selectionButton.Hide();
                _ownedImage.Hide();
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
                    if (_currentItemView.Item is CharacterSkinsItem skinItem)
                        CharacterSkinsItemClicked?.Invoke(skinItem);

                    _ownedImage.Show();
                    return;
                }

                _selectionButton.Show();
            }
            else
            {
                ShowBuyButton();
            }
        }

        protected override void ShowBuyButton()
        {
            _buyButton.Show();
            _selectionButton.Hide();
            _ownedImage.Hide();
        }
    }
}