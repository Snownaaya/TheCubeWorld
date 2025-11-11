using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public abstract class ShopItem : ScriptableObject
    {
        [field: SerializeField] public Item Model { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField, Range(0, 2500)] public int Price { get; private set; }
    }
}