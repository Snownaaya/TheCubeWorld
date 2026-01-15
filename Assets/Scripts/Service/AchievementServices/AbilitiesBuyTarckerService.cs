using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.UI.Shop.AbilitiesShop;

namespace Assets.Scripts.Service.AchievementServices
{
    public class AbilitiesBuyTarckerService : IAbilitiesBuyTracker
    {
        private AchievemntBuyObserver _achievemntBuyObserver;

        public AbilitiesBuyTarckerService(AchievemntBuyObserver achievemntBuyObserver) =>
            _achievemntBuyObserver = achievemntBuyObserver;

        public void Register(AbilitiesShop abilityShop) =>
            abilityShop.AbilityItemClicked += _achievemntBuyObserver.OnAbilityBuy;

        public void Unregister(AbilitiesShop abilityShop) =>
            abilityShop.AbilityItemClicked -= _achievemntBuyObserver.OnAbilityBuy;
    }
}