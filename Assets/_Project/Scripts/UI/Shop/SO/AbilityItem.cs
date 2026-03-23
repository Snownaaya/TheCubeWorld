namespace Assets.Scripts.UI.Shop.SO
{
    using Assets.Scripts.Enemies.Obstacles;
    using UnityEngine;

    [CreateAssetMenu(fileName = "AbilityItem", menuName = "Shop/AbilityItem")]
    public class AbilityItem : ShopItem
    {
        [field: SerializeField] public ObstacleTypes AbilityTypes { get; private set; }

        [field: SerializeField] public string AbilityInfo { get; private set; }
    }
}