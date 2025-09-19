using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.UI.MainMenu
{
    public class ShopButton : WindowView
    {
        [SerializeField] private RectTransform _rectShop;

        protected override void Close() =>
            _rectShop.gameObject.SetActive(false);

        protected override void Open() =>
            _rectShop.gameObject.SetActive(true);
    }
}
