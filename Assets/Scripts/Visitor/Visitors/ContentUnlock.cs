using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas.Character;

namespace Assets.Scripts.Visitor.Visitors
{
    public class ContentUnlock : IShopVisitor
    {
        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterdata;

        public ContentUnlock(IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterdata)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterdata = transientCharacterdata;
        }

        public void Visit(AbilityItem abilityItem) =>
           _transientCharacterdata.OpenAbility(abilityItem.AbilityTypes);

        public void Visit(CharacterSkinsItem characterSkinsItem) =>
            _persistentCharacterData.OpenCharacterSkin(characterSkinsItem.CharacterSkins);
    }
}