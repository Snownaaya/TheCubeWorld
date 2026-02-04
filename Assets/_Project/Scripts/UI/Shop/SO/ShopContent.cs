using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.UI.Shop.SO
{
    [CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
    public class ShopContent : ScriptableObject
    {
        [SerializeField] private List<AbilityItem> _abilityItems;
        [SerializeField] private List<CharacterSkinsItem> _characterSkinsItems;

        public IEnumerable<CharacterSkinsItem> CharacterSkinItem => _characterSkinsItems;
        public IEnumerable<AbilityItem> AbilityItems => _abilityItems;

        private void OnValidate()
        {
            var charaterSkinsDuplicates = _characterSkinsItems.GroupBy(item => item.CharacterSkins)
           .Where(array => array.Count() > 1);

            if (charaterSkinsDuplicates.Count() > 0)
                throw new InvalidOperationException(nameof(_characterSkinsItems));

            var mazeSkinsDuplicates = _abilityItems.GroupBy(item => item.AbilityTypes)
                .Where(array => array.Count() > 1);

            if (mazeSkinsDuplicates.Count() > 0)
                throw new InvalidOperationException(nameof(_abilityItems));
        }
    }
}