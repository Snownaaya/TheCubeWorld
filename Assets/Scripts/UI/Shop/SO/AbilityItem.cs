using Assets.Scripts.Enemies.Obstacles;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.SO
{
    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Shop/AbilityItem")]
    public class AbilityItem : ShopItem
    {
        [field: SerializeField] public ObstacleTypes AbilityTypes { get; private set; }
    }
}