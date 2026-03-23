namespace Assets.Scripts.Visitor
{
    using Assets.Scripts.UI.Shop.SO;

    public interface IShopVisitor
    {
        public void Visit(AbilityItem abilityItem);

        public void Visit(CharacterSkinsItem characterSkinsItem);
    }
}