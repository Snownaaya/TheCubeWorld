using Object = UnityEngine.Object; 
using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Visitor;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopItemFactory
    {
        private ShopItemView _abilityPrefab;
        //private ShopItemView _characterPrefab;

        public ShopItemFactory(ShopItemView abilityPrefab) //CharacterSkinsItem characterPrefab
        {
            _abilityPrefab = abilityPrefab;
            //_characterPrefab = characterPrefab;
        }

        public ShopItemView Get(ShopItem item, Transform parent)
        {
            VisitorFactory visitorFactory = new VisitorFactory();
            ShopItemEntry entry = visitorFactory.Create(item);

            ViewSelectorVisitor viewSelector = new ViewSelectorVisitor(
                _abilityPrefab
            //_abilityPrefab,
            //_characterPrefab
            );

            entry.Accept(viewSelector);

            ShopItemView instance = Object.Instantiate(viewSelector.Prefab, parent);
            instance.Initialize(item, entry);

            return instance;
        }
    }
}