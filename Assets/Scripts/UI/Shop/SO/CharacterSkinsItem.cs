using Assets.Scripts.Player.Core;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.SO
{
    [CreateAssetMenu(fileName = "CharacterSkinsItem", menuName = "Shop/CharacterSkinsItem")]
    public class CharacterSkinsItem : ShopItem
    {
        [field: SerializeField] public CharacterSkins CharacterSkins { get; private set; }
    }
}