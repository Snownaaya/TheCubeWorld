using UnityEngine;
using System;

namespace Assets.Scripts.Bridge.Factory
{
    [CreateAssetMenu(fileName = "BridgeFactory", menuName = "Factory/BridgeFactory")]
    public class BridgeFactory : ScriptableObject
    {
        [SerializeField] private BridgeConfig _esay, _middle, _hard;

        public Bridge Get(BridgeType bridgeType, Vector3 position)
        {
            BridgeConfig bridgeConfig = GetConfig(bridgeType);
            Bridge instance = Instantiate(bridgeConfig.BridgePrefab, position, Quaternion.identity);
            return instance;
        }

        public BridgeConfig GetConfig(BridgeType bridgeType)
        {
            switch (bridgeType)
            {
                case BridgeType.Easy:
                    return _esay;

                case BridgeType.Middle:
                    return _middle;

                case BridgeType.Hard:
                    return _hard;

                default:
                    throw new ArgumentException(nameof(bridgeType));
            }
        }
    }
}