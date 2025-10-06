using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Assets.Scripts.Shop
{
    public class ShopItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action Click;

        [SerializeField] private Sprite _standartBackground;

        [SerializeField] private Image _contentImage;
        [SerializeField] private Image _lockImage;

        private ShopItem _shopItem;

        public bool IsLock { get; private set; }
        public int Price => _shopItem.Price;

        public void OnPointerClick(PointerEventData eventData) =>
                 Click?.Invoke();

        public void Initialize(ShopItem shopItem)
        {
            _shopItem = shopItem;
        }

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
    }
}