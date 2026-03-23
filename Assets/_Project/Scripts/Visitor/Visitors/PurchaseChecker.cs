namespace Assets.Scripts.Visitor.Visitors
{
    using Assets.Scripts.Datas.Character;
    using Assets.Scripts.UI.Shop.SO;

    public class PurchaseChecker : IShopVisitor
    {
        private IPersistentCharacterData _persistentCharacterData;
        private ITransientCharacterData _transientCharacterData;

        public PurchaseChecker(
            IPersistentCharacterData persistentCharacterData,
            ITransientCharacterData transientCharacterData)
        {
            _persistentCharacterData = persistentCharacterData;
            _transientCharacterData = transientCharacterData;
        }

        public bool IsOwned { get; private set; } = true;

        public void Visit(AbilityItem abilityItem) =>
            IsOwned = _transientCharacterData.SelectedAbility == abilityItem.AbilityTypes;

        public void Visit(CharacterSkinsItem characterSkinsItem) =>
            IsOwned = _persistentCharacterData.SelectedCharacterSkin == characterSkinsItem.CharacterSkins;
    }
}