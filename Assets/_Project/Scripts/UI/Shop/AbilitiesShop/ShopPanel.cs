using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.AbilitiesShop
{
    public class ShopPanel : BaseShopPanel
    {
        [SerializeField] private Transform _itemsParent;

        [SerializeField] private ShopItemView _abilityPrefab;

        private ShopItemFactory _shopItemFactory;

        private VisitorsHolder _visitors;

        public event Action<ShopItemView> ItemViewClicked;

        public void Initialize(VisitorsHolder visitorsHolder,
            VisitorFactory visitorFactory)
        {
            _visitors = visitorsHolder;
            _shopItemFactory = new ShopItemFactory(_abilityPrefab, visitorFactory, null);
        }

        public void ItemClickView(IEnumerable<ShopItem> shopitems)
        {
            Clear();

            foreach (ShopItem item in shopitems)
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

            Sort();
        }

        private void Sort()
        {
            Items = Items
                .OrderBy(item => item.IsLock)
                .ThenByDescending(item => item.Price)
                .ToList();

            for (int i = 0; i < Items.Count; i++)
                Items[i].transform.SetSiblingIndex(i);
        }

        protected override void OnItemViewClick(ShopItemView itemView)
        {
            Highlight(itemView);
            ItemViewClicked?.Invoke(itemView);
        }
    }
}