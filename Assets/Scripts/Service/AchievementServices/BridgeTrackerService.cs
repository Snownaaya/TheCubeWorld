using Assets.Scripts.Achievements.Observers;

namespace Assets.Scripts.Service.AchievementServices
{
    public class BridgeTrackerService : IAchievementTracker<Bridge.Bridge>
    {
        private AchievementBridgeObserver _achievementBridgeObserver;

        public BridgeTrackerService(AchievementBridgeObserver achievementBridgeObserver) =>
            _achievementBridgeObserver = achievementBridgeObserver;

        public void Register(Bridge.Bridge bridge) =>
            bridge.Completed += _achievementBridgeObserver.OnBridgeCompleted;

        public void Unregister(Bridge.Bridge bridge) =>
            bridge.Completed -= _achievementBridgeObserver.OnBridgeCompleted;
    }
}
