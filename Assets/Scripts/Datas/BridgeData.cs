using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Items;
using System;

namespace Assets.Scripts.Datas
{
    [Serializable]
    public struct BridgeData
    {
        public BridgeData(BridgeType bridgeType, ResourceTypes resourceTypes)
        {
            BridgeType = bridgeType;
            ResourceTypes = resourceTypes;
        }

        public BridgeType BridgeType { get; }
        public ResourceTypes ResourceTypes {get;}
    }
}