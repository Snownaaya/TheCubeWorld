using Assets.Scripts.Bridge;
using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Datas;
using UnityEngine;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public class BuildButton : ButtonBase
    {
        [SerializeField] private ResourceConfig _resource;
        [SerializeField] private BridgeSpawner _bridgeSpawner;

        private Assets.Scripts.Bridge.Bridge _bridge;

        protected override void OnEnable()
        {
            base.OnEnable();

            _bridgeSpawner.OnBridgeSpawned += UpdateBridge;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _bridgeSpawner.OnBridgeSpawned -= UpdateBridge;
        }

        protected override void OnClickButton()
        {
            BuildingArea buildingArea = _bridge.GetComponentInChildren<BuildingArea>();
            buildingArea.DeliveResource(_resource);
        }

        private void UpdateBridge(Assets.Scripts.Bridge.Bridge newBridge) =>
            _bridge = newBridge;
    }
}