using System.Collections.Generic;
using Assets.Scripts.UI.Shop.SO;
using System;

namespace Assets.Scripts.Visitor
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
                sciptableObject => new ShopItemEntry(visitor => visitor.Visit((AbilityItem)sciptableObject))
            },
            //{
            //    typeof(CharacterSkinsItem),
            //    sciptableObject => new ShopItemEntry(visitor => visitor.Visit((CharacterSkinsItem)sciptableObject))
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