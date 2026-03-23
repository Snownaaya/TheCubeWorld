namespace Assets.Scripts.UI.Shop
{
    using Assets.Scripts.UI.Shop.SO;
    using Assets.Scripts.Visitor;

    public class ViewSelectorVisitor : IShopVisitor
    {
        private ShopItemView _abilityItemPrefab;
        private ShopItemView _characterSkinsItemPrefab;

        public ViewSelectorVisitor(ShopItemView abilityItemPrefab,
            ShopItemView characterSkinsItemPrefab)
        {
            _abilityItemPrefab = abilityItemPrefab;
            _characterSkinsItemPrefab = characterSkinsItemPrefab;
        }

        public ShopItemView Prefab { get; private set; }

        public void Visit(AbilityItem abilityItem) =>
            Prefab = _abilityItemPrefab;

        public void Visit(CharacterSkinsItem characterSkinsItem) =>
            Prefab = _characterSkinsItemPrefab;
    }
}