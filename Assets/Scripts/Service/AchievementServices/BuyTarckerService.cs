using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.UI.Shop.AbilitiesShop;

namespace Assets.Scripts.Service.AchievementServices
{
    public class BuyTarckerService : IAchievementTracker<BaseShop>
    {
        private AchievemntBuyObserver _achievemntBuyObserver;

        public BuyTarckerService(AchievemntBuyObserver achievemntBuyObserver) =>
            _achievemntBuyObserver = achievemntBuyObserver;

        public void Register(BaseShop @object)
        {
            
        }

        public void Unregister(BaseShop @object)
        {
            
        }
    }
}