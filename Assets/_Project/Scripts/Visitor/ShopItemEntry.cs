namespace Assets.Scripts.Visitor
{
    using System;

    public class ShopItemEntry : IShopElement
    {
        private Action<IShopVisitor> _acceptMethod;

        public ShopItemEntry(Action<IShopVisitor> acceptMethod) =>
            _acceptMethod = acceptMethod;

        public void Accept(IShopVisitor shopVisitor) =>
            _acceptMethod(shopVisitor);
    }
}