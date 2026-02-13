using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.SkinsShop
{
    public class SkinsShopPanel : BaseShopPanel
    {
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private ShopItemView _characterPrefab;

        private ShopItemFactory _shopItemFactory;
        private VisitorsHolder _visitors;

        public event Action<ShopItemView> ItemViewClicked;

        public void Initialize(
            VisitorsHolder visitorsHolder,
            VisitorFactory visitorFactory)
        {
            _visitors = visitorsHolder;
            _shopItemFactory = new ShopItemFactory(null, visitorFactory, _characterPrefab);
        }

        public void Populate(IEnumerable<ShopItem> shopItems)
        {
            Clear();

            foreach (ShopItem item in shopItems)
            {
                ShopItemView spawnedItem = _shopItemFactory.Get(item, _itemsParent);

                spawnedItem.ItemClicked += OnItemViewClick;

                spawnedItem.UnHighlight();

                spawnedItem.Entry.Accept(_visitors.UnlockChecker);

                if (_visitors.UnlockChecker.IsUnlock)
                {
                    spawnedItem.Entry.Accept(_visitors.PurchaseChecker);

                    if (_visitors.PurchaseChecker.IsOwned)
                    {
                        Highlight(spawnedItem);
                        ItemViewClicked?.Invoke(spawnedItem);
                    }

                    spawnedItem.HidePrice();
                    spawnedItem.Unlock();
                }
                else
                {
                    spawnedItem.ShowPrice();
                    spawnedItem.Lock();
                }

                Items.Add(spawnedItem);
            }
        }

        protected override void OnItemViewClick(ShopItemView itemView)
        {
            Highlight(itemView);
            ItemViewClicked?.Invoke(itemView);
        }
    }
}
