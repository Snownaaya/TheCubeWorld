using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Other;
using UnityEngine;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public class TypeSelectorButton : ButtonBase
    {
        [SerializeField] private BridgeConfig _bridgeConfig;
        [SerializeField] private SpawnerSelector _spawnerSelector;

        [SerializeField] private float _distance;

        protected override void OnClickButton()
        {
            Vector3 playerPosition = PlayerPositionUtils.GetPlayerPosition();
            BridgeSpawner bridgeSpawner = _spawnerSelector.SetCurrentSpawner(_spawnerSelector.GetClosestSpawner(playerPosition));

            if (Vector3.Distance(playerPosition, bridgeSpawner.Point.position) < _distance)
                bridgeSpawner.SelectBridge(_bridgeConfig.BridgeType);
        }
    }
}