using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public abstract class BaseShopPanel : MonoBehaviour
    {
        protected List<ShopItemView> Items = new();

        protected void Highlight(ShopItemView shopItemView)
        {
            foreach (var item in Items)
                item.UnHighlight();

            shopItemView.Highlight();
        }

        protected void Clear()
        {
            foreach (ShopItemView item in Items)
            {
                item.ItemClicked -= OnItemViewClick;
                Destroy(item.gameObject);
            }

            Items.Clear();
        }

        protected abstract void OnItemViewClick(ShopItemView itemView);
    }
}