using UnityEngine;

namespace Assets.Scripts.Shop.Ability
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Shop/AbilityItem")]
    public class AbilityItem : ShopItem
    {
        [field: SerializeField] public AbilityTypes AbilityTypes { get; private set; }
    }
}