using Assets.Scripts.UI.Shop.SO;

namespace Assets.Scripts.Visitor
{
    public interface IShopVisitor
    {
        public void Visit(AbilityItem abilityItem);
        public void Visit(CharacterSkinsItem characterSkinsItem);
    }
}