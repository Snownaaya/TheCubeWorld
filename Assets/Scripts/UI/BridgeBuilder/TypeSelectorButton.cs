using Assets.Scripts.Bridge.Factory;
using UnityEngine;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public class TypeSelectorButton : ButtonBase
    {
        [SerializeField] private BridgeSpawner _bridgeSpawner;
        [SerializeField] private BridgeType _bridgeType;

        protected override void OnClickButton()
        {
            //if (Vector3.Distance(transform.position, _bridgeSpawner.Point.transform.position) < 1)
                _bridgeSpawner.SelectBridge(_bridgeType);
        }

        public void GetBridgeCount(BridgeType bridgeType)
        {
            
        }
    }
}