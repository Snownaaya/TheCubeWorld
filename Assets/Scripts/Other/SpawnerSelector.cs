using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Other
{
    public class SpawnerSelector : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner[] _spawners;

        private BridgeSpawner _currentSpawner;

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

        public BridgeSpawner SetCurrentSpawner(BridgeSpawner bridgeSpawner)
        {
            _currentSpawner = bridgeSpawner;
            return _currentSpawner;
        }

        public BridgeSpawner GetCurrentSpawner()
        {
            Vector3 playerPosition = PlayerPositionUtils.GetPlayerPosition();
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