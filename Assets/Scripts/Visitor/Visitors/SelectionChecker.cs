using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Visitor.Visitors
{
    public class SelectionChecker : IShopVisitor
    {
        private CharacterData _characterData;

        public SelectionChecker(CharacterData characterData) =>
            _characterData = characterData;

        public bool IsSelected { get; private set; }

        public void Visit(AbilityItem abilityItem) =>
            IsSelected = _characterData.SelectedAbility == abilityItem.AbilityTypes;

        //public void Visit(CharacterSkinsItem characterSkinsItem) =>
        //    IsSelected = _characterData.SelectedCharacterSkin == characterSkinsItem.CharacterSkins;
    }
}