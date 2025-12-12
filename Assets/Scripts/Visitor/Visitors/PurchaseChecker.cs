using Assets.Scripts.UI.Shop.SO;
using Assets.Scripts.Datas.Character;

namespace Assets.Scripts.Visitor.Visitors
{
    public class PurchaseChecker : IShopVisitor
    {
        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterData;

        public PurchaseChecker(IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterData)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterData = transientCharacterData;
        }

        public bool IsOwned { get; private set; }

        public void Visit(AbilityItem abilityItem) =>
            IsOwned = _transientCharacterData.SelectedAbility == abilityItem.AbilityTypes;

        public void Visit(CharacterSkinsItem characterSkinsItem) =>
            IsOwned = _persistentCharacterData.SelectedCharacterSkin == characterSkinsItem.CharacterSkins;
    }
}