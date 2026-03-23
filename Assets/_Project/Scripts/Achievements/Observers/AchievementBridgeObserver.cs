namespace Assets.Scripts.Achievements.Observers
{
    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Bridge.Factory;
    using Assets.Scripts.Datas;
    using Assets.Scripts.Items;

    public class AchievementBridgeObserver
    {
        private Queue<BridgeData> _bridges = new ();
        private int _maxCountBridges = 10;

        private IEnumerable<Action<Queue<BridgeData>>> _bridgeCheckers;

        public AchievementBridgeObserver(IEnumerable<Action<Queue<BridgeData>>> bridgeCheckers) =>
            _bridgeCheckers = bridgeCheckers;

        public void OnBridgeCompleted(ResourceTypes resourceType, BridgeType bridgeType)
        {
            _bridges.Enqueue(new BridgeData(bridgeType, resourceType));

            if (_bridges.Count > _maxCountBridges)
                _bridges.Dequeue();

            foreach (Action<Queue<BridgeData>> bridgeCheck in _bridgeCheckers)
                bridgeCheck(_bridges);
        }
    }
}