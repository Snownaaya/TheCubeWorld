using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Other;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public class TypeSelectorButton : ButtonBase
    {
        [SerializeField] private BridgeConfig _bridgeConfig;
        [SerializeField] private SpawnerSelector _spawnerSelector;

        [SerializeField] private float _distance;

        private CharacterHolder _characterHolder;

        [Inject]
        private void Construct(CharacterHolder characterHolder) =>
            _characterHolder = characterHolder;

        protected override void OnClickButton()
        {
            Vector3 playerPosition = _characterHolder.Movement.CharacterModel.position;
            BridgeSpawner bridgeSpawner = _spawnerSelector.SetCurrentSpawner(_spawnerSelector.GetClosestSpawner(playerPosition));

            if (Vector3.Distance(playerPosition, bridgeSpawner.Point.position) < _distance)
                bridgeSpawner.SelectBridge(_bridgeConfig.BridgeType);
        }
    }
}