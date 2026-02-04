using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.UI.Shop.SkinsShop;
using Assets.Scripts.UI.Shop.SO;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Mediators.Shop
{
    public class ShopSkinsMediators : MonoBehaviour
    {
        [SerializeField] private SkinsShop _shop;

        private ICharacterHolder _characterHolder;
        private ISkinsBuyTracker _buyTracker;

        [Inject]
        private void Construct(
            ICharacterHolder characterHolder,
            ISkinsBuyTracker buyTracker)
        {
            _buyTracker = buyTracker;
            _characterHolder = characterHolder;
        }

        private void OnEnable()
        {
            _shop.CharacterSkinsItemClicked += OnSkinChange;
            _buyTracker.Register(_shop);
        }

        private void OnDisable()
        {
            if (_shop != null)
                _shop.CharacterSkinsItemClicked -= OnSkinChange;

            if (_buyTracker != null && _shop != null)
                _buyTracker.Unregister(_shop);
        }

        private void OnSkinChange(CharacterSkinsItem item) =>
            _characterHolder.SkinChanger.Change(item.CharacterSkins);
    }
}