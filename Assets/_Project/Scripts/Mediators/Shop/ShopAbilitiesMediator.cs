using Assets.Project.Scripts.Ground.Filler;
using Assets.Scripts.Enemies.Obstacles;
using Assets.Scripts.Enemies.Obstacles.Animation;
using Assets.Scripts.Enemies.Obstacles.Patrollers;
using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.UI.Shop.AbilitiesShop;
using Assets.Scripts.UI.Shop.SO;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Mediators
{
    public class ShopAbilitiesMediator : MonoBehaviour
    {
        [SerializeField] private AbilitiesShop _shop;
        [SerializeField] private PatrollerStopper _patrolerStopper;
        [SerializeField] private SpikesAnimation _spikesAnimation;

        private IAbilitiesBuyTracker _achievementTracker;
        private LevelHazard _levelHazard;

        [Inject]
        private void Construct(
            IAbilitiesBuyTracker achievementTracker,
            LevelHazard levelHazard)
        {
            _achievementTracker = achievementTracker;
            _levelHazard = levelHazard; 
        }

        private void OnEnable()
        {
            _shop.AbilityItemClicked += OnDeactive;
            _achievementTracker.Register(_shop);
        }

        private void OnDisable()
        {
            _shop.AbilityItemClicked -= OnDeactive; 
            _achievementTracker.Unregister(_shop);
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
                    _levelHazard.Stop();
                    break;

                case ObstacleTypes.Spikes:
                    _spikesAnimation.Stopped();
                    break;
            }
        }
    }
}