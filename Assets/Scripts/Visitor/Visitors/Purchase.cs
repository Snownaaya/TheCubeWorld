using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Visitor.Visitors
{
    public class Purchase : IShopVisitor
    {
        private CharacterData _characterData;

        public Purchase(CharacterData characterData) =>
            _characterData = characterData;

        public void Visit(AbilityItem abilityItem) =>
            _characterData.SelectedAbility = abilityItem.AbilityTypes;

        //public void Visit(CharacterSkinsItem characterSkinsItem) =>
        //    _characterData.SelectedCharacterSkin = characterSkinsItem.CharacterSkins;
    }
}