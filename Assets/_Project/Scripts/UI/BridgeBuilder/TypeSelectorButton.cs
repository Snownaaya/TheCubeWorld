namespace Assets.Scripts.UI.BridgeBuilder
{
    using Assets.Scripts.Bridge;
    using Assets.Scripts.Bridge.Factory;
    using Assets.Scripts.Player.Core;
    using Reflex.Attributes;
    using UnityEngine;

    public class TypeSelectorButton : ButtonBase
    {
        [SerializeField] private BridgeConfig _bridgeConfig;
        [SerializeField] private SpawnerSelector _spawnerSelector;

        [SerializeField] private float _distance;

        private ICharacterHolder _characterHolder;

        [Inject]
        private void Construct(ICharacterHolder characterHolder) =>
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