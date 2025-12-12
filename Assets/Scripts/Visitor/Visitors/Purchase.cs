using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas.Character;

namespace Assets.Scripts.Visitor.Visitors
{
    public class Purchase : IShopVisitor
    {
        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterData;

        public Purchase(IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterdata)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterData = transientCharacterdata;
        }

        public void Visit(AbilityItem abilityItem) =>
            _transientCharacterData.SelectedAbility = abilityItem.AbilityTypes;

        public void Visit(CharacterSkinsItem characterSkinsItem) =>
            _persistentCharacterData.SelectedCharacterSkin = characterSkinsItem.CharacterSkins;
    }
}