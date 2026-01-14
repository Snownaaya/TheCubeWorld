using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Player.Skins;
using Assets.Scripts.Visitor;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.AbilitiesShop
{
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