using Assets.Scripts.Interfaces;
using Assets.Scripts.UI.Shop.SO;
using UnityEngine.EventSystems;
using Assets.Scripts.Visitor;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;

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

        public void UnHighlight() =>
            _backgroundImage.DOColor(Color.white, 0.3f);

        public void Highlight() =>
            _backgroundImage.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.3f);
    }
}