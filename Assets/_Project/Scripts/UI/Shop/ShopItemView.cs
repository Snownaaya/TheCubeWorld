namespace Assets.Scripts.UI.Shop
{
    using System;
    using Assets.Project.Scripts.UI.Shop;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.UI.Shop.SO;
    using Assets.Scripts.Visitor;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ShopItemView : MonoBehaviour, ILockable, IPointerClickHandler
    {
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _contentImage;
        [SerializeField] private TogglePrice _price;

        public event Action<ShopItemView> ItemClicked;

        public ShopItem Item { get; private set; }

        public ShopItemEntry Entry { get; private set; }

        public bool IsLock { get; private set; }

        public int Price => Item.Price;

        public void Initialize(
            ShopItem shopItem,
            ShopItemEntry entry)
        {
            Item = shopItem;
            Entry = entry;

            _contentImage.sprite = Item.Image;
        }

        public void OnPointerClick(PointerEventData eventData) =>
            ItemClicked?.Invoke(this);

        public void Lock()
        {
            IsLock = true;
            _lockImage.gameObject.SetActive(true);
        }

        public void Unlock()
        {
            IsLock = false;
            _lockImage.gameObject.SetActive(false);
        }

        public void HidePrice()
        {
            IsLock = false;
            _price.gameObject.SetActive(false);
        }

        public void ShowPrice()
        {
            IsLock = true;
            _price.gameObject.SetActive(true);
        }

        public void UnHighlight()
        {
            _backgroundImage
                .DOColor(Color.white, 0.3f);
        }

        public void Highlight() =>
            _backgroundImage
            .DOColor(Color.gray, 0.3f)
            .DOTimeScale(15, 2);
    }
}