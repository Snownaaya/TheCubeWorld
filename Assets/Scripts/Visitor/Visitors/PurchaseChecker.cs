using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas;
using UnityEngine;

namespace Assets.Scripts.Visitor.Visitors
{
    public class PurchaseChecker : IShopVisitor
    {
        private CharacterData _characterData;

        public PurchaseChecker(CharacterData characterData) =>
            _characterData = characterData;

        public bool IsOwned { get; private set; }

        public void Visit(AbilityItem abilityItem) =>
            IsOwned = _characterData.SelectedAbility == abilityItem.AbilityTypes;

        //public void Visit(CharacterSkinsItem characterSkinsItem) =>
        //    IsSelected = _characterData.SelectedCharacterSkin == characterSkinsItem.CharacterSkins;
    }
}