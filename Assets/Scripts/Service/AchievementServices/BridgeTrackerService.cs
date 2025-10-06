using Assets.Scripts.Achievements;
using Assets.Scripts.Achievements.Observers;
using UnityEngine;

namespace Assets.Scripts.Service.AchievementServices
{
    public class BridgeTrackerService
    {
        private AchievementBridgeObserver _achievementBridgeObserver;

        public BridgeTrackerService(AchievementBridgeObserver achievementBridgeObserver) =>
            _achievementBridgeObserver = achievementBridgeObserver;

        public void RegisterBridge(Bridge.Bridge bridge)
        {
            bridge.Completed += _achievementBridgeObserver.OnBridgeCompleted;
            Debug.Log($"{bridge} completed");
        }

        public void UnregisterBridge(Bridge.Bridge bridge) =>
            bridge.Completed -= _achievementBridgeObserver.OnBridgeCompleted;
    }
}
