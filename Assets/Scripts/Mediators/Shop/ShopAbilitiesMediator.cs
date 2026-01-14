using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Enemies.Obstacles.Animation;
using Assets.Scripts.Enemies.Obstacles.Patrollers;
using Assets.Scripts.Ground.Filler;
using Assets.Scripts.UI.Shop.AbilitiesShop;
using Assets.Scripts.UI.Shop.SO;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class ShopAbilitiesMediator : MonoBehaviour
    {
        [SerializeField] private AbilitiesShop _shop;
        [SerializeField] private LevelStopper _levelStopper;
        [SerializeField] private PatrollerStopper _patrolerStopper;
        [SerializeField] private SpikesAnimation _spikesAnimation;

        private void OnEnable() =>
            _shop.AbilityItemClicked += OnDeactive;

        private void OnDisable() =>
            _shop.AbilityItemClicked -= OnDeactive; 

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
    }
}