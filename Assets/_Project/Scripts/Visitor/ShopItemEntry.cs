using System;

namespace Assets.Scripts.Visitor
{
    public class ShopItemEntry : IShopElement
    {
        private Action<IShopVisitor> _acceptMethod;

        public ShopItemEntry(Action<IShopVisitor> acceptMethod) =>
            _acceptMethod = acceptMethod;

        public void Accept(IShopVisitor shopVisitor) =>
            _acceptMethod(shopVisitor);
    }
}