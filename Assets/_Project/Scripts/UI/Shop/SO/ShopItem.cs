using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Shop.SO
{
    public abstract class ShopItem : ScriptableObject
    {
        [field: SerializeField] public int Price { get; private set; }

        [field: SerializeField] public Sprite Image { get; private set; }
    }
}