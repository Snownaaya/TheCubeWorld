using Assets.Scripts.Datas;
using Assets.Scripts.UI.Shop;
using Assets.Scripts.UI.Shop.SO;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Visitor.Visitors
{
    public class UnlockChecker : IShopVisitor
    {
        private CharacterData _characterData;

        public UnlockChecker(CharacterData characterData) =>
            _characterData = characterData;

        public bool IsUnlock { get; private set; }

        public void Visit(AbilityItem abilityItem)
        {
            IsUnlock = _characterData.OpenAbilities.Contains(abilityItem.AbilityTypes);
            Debug.Log($"UnlockChecker: {abilityItem.AbilityTypes} -> {IsUnlock}");
        }

        //public void Visit(CharacterSkinsItem characterSkinsItem) =>
        //    IsUnlock = _characterData.OpenCharacterSkins.Contains(characterSkinsItem.CharacterSkins);
    }
}