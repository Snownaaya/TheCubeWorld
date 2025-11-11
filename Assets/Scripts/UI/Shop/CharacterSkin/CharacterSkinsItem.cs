using UnityEngine;

namespace Assets.Scripts.UI.Shop.CharacterSkin
{
    [CreateAssetMenu(fileName = "CharacterSkinsItem", menuName = "Shop/CharacterSkinsItem")]
    public class CharacterSkinsItem
    {
        [field: SerializeField] public CharacterSkins CharacterSkins { get; private set; }
    }
}
