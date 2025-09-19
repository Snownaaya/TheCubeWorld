using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Items;
using System;

namespace Assets.Scripts.Datas
{
    [Serializable]
    public class BridgeData
    {
        private BridgeType _bridgeType;
        private ResourceTypes _resourceTypes;

        public BridgeData(BridgeType bridgeType, ResourceTypes resourceTypes)
        {
            _bridgeType = bridgeType;
            _resourceTypes = resourceTypes;
        }

        public BridgeType BridgeType 
        { 
            get => _bridgeType; 
            set => _bridgeType = value; 
        }   
        public ResourceTypes ResourceTypes 
        { 
            get => _resourceTypes; 
            set => _resourceTypes = value; 
        }
    }
}