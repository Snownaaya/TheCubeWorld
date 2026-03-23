namespace Assets.Scripts.Service.AchievementServices
{
    using Assets.Scripts.Achievements.Observers;
    using Assets.Scripts.UI.Shop.SkinsShop;

    public class SkinBuyTracker : ISkinsBuyTracker
    {
        private AchievemntBuyObserver _achievemntBuyObserver;

        public SkinBuyTracker(AchievemntBuyObserver achievemntBuyObserver) =>
            _achievemntBuyObserver = achievemntBuyObserver;

        public void Register(SkinsShop skinsShop) =>
            skinsShop.CharacterSkinsItemClicked += _achievemntBuyObserver.OnSkinBuy;

        public void Unregister(SkinsShop skinsShop) =>
            skinsShop.CharacterSkinsItemClicked -= _achievemntBuyObserver.OnSkinBuy;
    }
}