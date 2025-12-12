using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Enemies.Obstacles.Animation;
using Assets.Scripts.Enemies.Obstacles.Patrollers;
using Assets.Scripts.Ground.Filler;
using Assets.Scripts.Player.Core;
using Assets.Scripts.UI.Shop;
using Assets.Scripts.UI.Shop.SO;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class ShopMediator : MonoBehaviour
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private LevelStopper _levelStopper;
        [SerializeField] private PatrollerStopper _patrolerStopper;
        [SerializeField] private SpikesAnimation _spikesAnimation;

        private CharacterHolder _characterHolder;

        [Inject]
        private void Construct(CharacterHolder characterHolder) =>
            _characterHolder = characterHolder;

        private void OnEnable()
        {
            _shop.AbilityItemClicked += OnDeactive;
            _shop.CharacterSkinsItemClicked += OnSkinChange;
        }

        private void OnDisable()
        {
            _shop.AbilityItemClicked -= OnDeactive; 
            _shop.CharacterSkinsItemClicked -= OnSkinChange;
        }

        private void OnDeactive(AbilityItem abilityItem)
        {
            switch (abilityItem.AbilityTypes)
            {
                case ObstacleTypes.Cylinder:
                    _patrolerStopper.ObstacleStopped(ObstacleTypes.Cylinder);
                    break;

                case ObstacleTypes.Gear:
                    _patrolerStopper.ObstacleStopped(ObstacleTypes.Gear);
                    break;

                case ObstacleTypes.Lava:
                    _levelStopper.LevelStopped();
                    break;

                case ObstacleTypes.Spikes:
                    _spikesAnimation.Stopped();
                    break;
            }
        }

        private void OnSkinChange(CharacterSkinsItem item) =>
            _characterHolder.SkinChanger.Change(item.CharacterSkins);
    }
}