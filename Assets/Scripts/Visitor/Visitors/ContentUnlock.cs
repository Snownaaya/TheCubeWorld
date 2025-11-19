using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Visitor.Visitors
{
    public class ContentUnlock : IShopVisitor
    {
        private CharacterData _characterData;

        public ContentUnlock(CharacterData characterData) =>
            _characterData = characterData;

        public void Visit(AbilityItem abilityItem) =>
           _characterData.OpenAbility(abilityItem.AbilityTypes);

        //public void Visit(CharacterSkinsItem characterSkinsItem) =>
        //    _characterData.OpenCharacterSkin(characterSkinsItem.CharacterSkins);
    }
}