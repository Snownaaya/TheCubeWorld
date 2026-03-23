namespace Assets.Scripts.UI.Shop.AbilitiesShop
{
    using System;
    using Assets.Scripts.Visitor;
    using UnityEngine;

    public abstract class BaseShop : MonoBehaviour, IDisposable
    {
        public abstract void Initialize(
            VisitorsHolder visitorsHolder,
            VisitorFactory visitorFactory);

        protected virtual void OnItemViewClick(ShopItemView view)
        {

        }

        protected abstract void OnBuyClicked();

        protected abstract void ShowBuyButton();

        public void Dispose() { }
    }
}