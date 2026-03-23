namespace Assets.Scripts.UI.Shop
{
    using System.Collections.Generic;
    using Assets.Project.Scripts.UI.GameUI;
    using UnityEngine;

    public abstract class BaseShopPanel : MonoBehaviour
    {
        [field: SerializeField] public CloseButton CloseButton { get; private set; }

        protected List<ShopItemView> Items = new ();

        protected void Highlight(ShopItemView shopItemView)
        {
            foreach (var item in Items)
                item.UnHighlight();

            shopItemView.Highlight();
        }

        protected virtual void Clear()
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