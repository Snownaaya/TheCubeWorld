using Assets.Scripts.UI.Shop;
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;

    [SerializeField] private ShopItemView _abilityPrefab;
    [SerializeField] private ShopItemView _characterPrefab;

    private ShopItemFactory _shopItemFactory;

    private VisitorsHolder _visitors;
    private List<ShopItemView> _items = new List<ShopItemView>();

    public event Action<ShopItemView> ItemViewClicked;

    public void Initialize(VisitorsHolder visitorsHolder, VisitorFactory visitorFactory)
    {
        _visitors = visitorsHolder;
        _shopItemFactory = new ShopItemFactory(_abilityPrefab, visitorFactory , _characterPrefab);
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
                spawnedItem.Entry.Accept(_visitors.SelectionChecker);

                if (_visitors.SelectionChecker.IsOwned)
                {
                    Highlight(spawnedItem);
                    ItemViewClicked?.Invoke(spawnedItem);
                }

                spawnedItem.Unlock();
            }
            else
            {
                spawnedItem.Lock();
            }

            _items.Add(spawnedItem);
        }

        Sort();
    }

    private void Sort()
    {
        _items = _items
            .OrderBy(item => item.IsLock)
            .ThenByDescending(item => item.Price)
            .ToList();

        for (int i = 0; i < _items.Count; i++)
            _items[i].transform.SetSiblingIndex(i);
    }

    private void OnItemViewClick(ShopItemView itemView)
    {
        Highlight(itemView);
        ItemViewClicked?.Invoke(itemView);
    }

    private void Highlight(ShopItemView shopItemView)
    {
        foreach (var item in _items)
            item.UnHighlight();

        shopItemView.Highlight();
    }

    private void Clear()
    {
        foreach (ShopItemView item in _items)
        {
            item.ItemClicked -= OnItemViewClick;
            Destroy(item.gameObject);
        }

        _items.Clear();
    }
}