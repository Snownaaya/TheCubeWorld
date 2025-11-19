using System.Collections.Generic;
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using System;

namespace Assets.Scripts.UI.Shop
{
    public class VisitorFactory
    {
        private readonly Dictionary<Type, Func<ShopItem, ShopItemEntry>> _factoryMap;

        public VisitorFactory()
        {
            _factoryMap = new Dictionary<Type, Func<ShopItem, ShopItemEntry>>
        {
            {
                typeof(AbilityItem),
                so => new ShopItemEntry(visitor => visitor.Visit((AbilityItem)so))
            },
            //{
            //    typeof(CharacterSkinsItem),
            //    so => new ShopItemEntry(visitor => visitor.Visit((CharacterSkinsItem)so))
            //}
        };
        }

        public ShopItemEntry Create(ShopItem item)
        {
            var type = item.GetType();

            if (_factoryMap.TryGetValue(type, out var creator))
                return creator(item);

            throw new InvalidOperationException($"Unknown ShopItem type: {type}");
        }
    }
}