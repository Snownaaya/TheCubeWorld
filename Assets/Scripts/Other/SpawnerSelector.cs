using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Player.Core;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Other
{
    public class SpawnerSelector : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner[] _spawners;

        private BridgeSpawner _currentSpawner;

        private CharacterHolder _characterHolder;

        private void OnValidate()
        {
            foreach (BridgeSpawner spawner in _spawners)
            {
                if (spawner != null)
                {
                    _currentSpawner = spawner;
                    break;
                }
            }
        }

        [Inject]
        private void Construct(CharacterHolder characterHolder) =>
            _characterHolder = characterHolder;

        public BridgeSpawner SetCurrentSpawner(BridgeSpawner bridgeSpawner)
        {
            _currentSpawner = bridgeSpawner;
            return _currentSpawner;
        }

        public BridgeSpawner GetCurrentSpawner()
        {
            Vector3 playerPosition = _characterHolder.Movement.transform.position;
            BridgeSpawner bridgeSpawner = SetCurrentSpawner(GetClosestSpawner(playerPosition));
            return bridgeSpawner;
        }

        public BridgeSpawner GetClosestSpawner(Vector3 position)
        {
            BridgeSpawner closestSpawner = null;

            float minDistance = float.MaxValue;

            foreach (BridgeSpawner spawner in _spawners)
            {
                float distance = Vector3.Distance(position, spawner.Point.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestSpawner = spawner;
                }
            }

            return closestSpawner;
        }
    }
}