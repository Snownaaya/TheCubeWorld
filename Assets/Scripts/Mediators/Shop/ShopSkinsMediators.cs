using Assets.Scripts.Player.Core;
using Assets.Scripts.UI.Shop.SkinsShop;
using Assets.Scripts.UI.Shop.SO;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Mediators.Shop
{
    public class ShopSkinsMediators : MonoBehaviour
    {
        [SerializeField] private SkinsShop _shop;

        private CharacterHolder _characterHolder;

        [Inject]
        private void Construct(CharacterHolder characterHolder) =>
            _characterHolder = characterHolder;

        private void OnEnable() =>
            _shop.CharacterSkinsItemClicked += OnSkinChange;

        private void OnDisable() =>
            _shop.CharacterSkinsItemClicked -= OnSkinChange;

        private void OnSkinChange(CharacterSkinsItem item) =>
            _characterHolder.SkinChanger.Change(item.CharacterSkins);
    }
}