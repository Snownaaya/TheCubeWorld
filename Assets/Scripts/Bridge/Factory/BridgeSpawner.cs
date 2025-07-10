using Assets.Scripts.Particles;
using Assets.Scripts.Particles.ParticliesSpawners;
using System;
using UnityEngine;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;
        [SerializeField] private BridgeEffect _bridgeEffect;
        [SerializeField] private PooledParticle _pooledParticle;

        private Bridge _currentBridge;
        private BridgeType _selectedType = BridgeType.Easy;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

        public void SpawnBridge()
        {
            if (_currentBridge != null)
                Destroy(_currentBridge.gameObject);

            _bridgeEffect.Initialize(_pooledParticle, transform);
            _currentBridge = _factory.Get(_selectedType, _point.position);
            _bridgeEffect.SpawnParticle();
        }

        public void SelectBridge(BridgeType bridgeType)
        {
            _selectedType = bridgeType;
            SpawnBridge();
        }
    }
}