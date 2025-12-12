using Assets.Scripts.Datas.Character;
using Assets.Scripts.UI.Shop.SO;
using System;
using System.Linq;

namespace Assets.Scripts.Visitor.Visitors
{
    public class UnlockChecker : IShopVisitor
    {
        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterData;

        public UnlockChecker(IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterData)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterData = transientCharacterData;
        }

        public bool IsUnlock { get; private set; }

        public void Visit(AbilityItem abilityItem)
        {
            IsUnlock = _transientCharacterData.OpenAbilities.Contains(abilityItem.AbilityTypes); 
        }

        public void Visit(CharacterSkinsItem characterSkinsItem)
        {
            IsUnlock = _persistentCharacterData.OpenCharacterSkins.Contains(characterSkinsItem.CharacterSkins);
        }
    }
}