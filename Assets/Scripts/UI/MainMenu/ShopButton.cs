using Assets.Scripts.UI.Shop;
using Assets.Scripts.UI.GameUI;
using UnityEngine;
using Assets.Scripts.UI.Shop.SO;

namespace Assets.Scripts.UI.MainMenu
{
    public class ShopButton : WindowView
    {
        [SerializeField] private RectTransform _rectShop;
        [SerializeField] private BackgroundPanel _backgroundPanel;
        [SerializeField] private ShopPanel _shopPanel;
        [SerializeField] private ShopContent _shopContent;

        protected override void Close()
        {
            _rectShop.gameObject.SetActive(false);
            _backgroundPanel.Hide();
        }

        protected override void Open()
        {
            _rectShop.gameObject.SetActive(true);
            _backgroundPanel.Show();
            _shopPanel.ItemClickView(_shopContent.AbilityItems);
        }
    }
}