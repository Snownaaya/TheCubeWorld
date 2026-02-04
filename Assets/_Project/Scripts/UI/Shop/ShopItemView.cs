using Assets.Scripts.Interfaces;
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using DG.Tweening;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopItemView : MonoBehaviour, ILockable, IPointerClickHandler
    {
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _contentImage;

        public ShopItem Item { get; private set; }
        public ShopItemEntry Entry { get; private set; }
        public bool IsLock { get; private set; }
        public int Price => Item.Price;

        public event Action<ShopItemView> ItemClicked;

        public void Initialize(ShopItem shopItem, ShopItemEntry entry)
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
            _lockImage.gameObject.SetActive(IsLock);
        }

        public void Unlock()
        {
            IsLock = false;
            _lockImage.gameObject.SetActive(IsLock);
        }

        public void UnHighlight()
        {
            _backgroundImage
                .DOColor(Color.white, 0.3f);
        }

        public void Highlight() =>
            _backgroundImage.DOColor(Color.gray, 0.3f).DOTimeScale(15, 2);
    }
}