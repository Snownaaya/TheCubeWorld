namespace Assets.Scripts.Datas
{
    using System;
    using Assets.Scripts.Bridge.Factory;
    using Assets.Scripts.Items;

    [Serializable]
    public readonly struct BridgeData
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