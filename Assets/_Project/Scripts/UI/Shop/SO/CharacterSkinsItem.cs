namespace Assets.Scripts.UI.Shop.SO
{
    using Assets.Scripts.Player.Skins;
    using UnityEngine;

    [CreateAssetMenu(fileName = "CharacterSkinsItem", menuName = "Shop/CharacterSkinsItem")]
    public class CharacterSkinsItem : ShopItem
    {
        [field: SerializeField] public CharacterSkins CharacterSkins { get; private set; }
    }
}