using Object = UnityEngine.Object; 
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopItemFactory
    {
        private ShopItemView _abilityPrefab;
        private ShopItemView _characterPrefab;

        private VisitorFactory _visitorFactory;

        public ShopItemFactory(ShopItemView abilityPrefab,
            ShopItemView characterPrefab)
        {
            _abilityPrefab = abilityPrefab;
            _characterPrefab = characterPrefab;
            _visitorFactory = new VisitorFactory();
        }

        public ShopItemView Get(ShopItem item, Transform parent)
        {
            ShopItemEntry entry = _visitorFactory.Create(item);

            ViewSelectorVisitor viewSelector = new ViewSelectorVisitor(
                _abilityPrefab,
                _characterPrefab
            );

            entry.Accept(viewSelector);

            ShopItemView instance = Object.Instantiate(viewSelector.Prefab, parent);
            instance.Initialize(item, entry);

            return instance;
        }
    }
}