using System;
using UnityEngine;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;

        private Bridge _currentBridge;
        private BridgeType _selectedType = BridgeType.Easy;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

        public void SpawnBridge()
        {
            if (_currentBridge != null)
                Destroy(_currentBridge.gameObject);

            _currentBridge = _factory.Get(_selectedType, _point.position);
        }

        public void SelectBridge(BridgeType bridgeType)
        {
            _selectedType = bridgeType;
            SpawnBridge();
        }
    }
}