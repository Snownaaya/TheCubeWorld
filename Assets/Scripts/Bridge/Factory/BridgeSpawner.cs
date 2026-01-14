using Assets.Scripts.Service.AchievementServices;
using Assets.Scripts.Particles;
using Reflex.Attributes;
using UnityEngine;
using System;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;

        private BridgeType _selectedType = BridgeType.Easy;
        private IParticleSpawner _bridgeEffect;
        private Bridge _currentBridge;
        private BridgeTrackerService _trackerService;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

        public event Action<Bridge> OnSpawned;

        [Inject]
        private void Construct(
            IParticleSpawner particleSpawner,
            BridgeTrackerService bridgeTracker)
        {
            _trackerService = bridgeTracker;
            _bridgeEffect = particleSpawner;
        }

        public void SpawnBridge()
        {
            if (_currentBridge != null)
            {
                _trackerService.Unregister(_currentBridge);
                Destroy(_currentBridge.gameObject);
            }

            OnSpawned?.Invoke(_currentBridge);
            _bridgeEffect.Initialize(transform);
            _currentBridge = _factory.Get(_selectedType, _point.position);
            _trackerService.Register(_currentBridge);
            _bridgeEffect.SpawnParticle(ParticleTypes.BridgeBuild, transform.position);
        }

        public void SelectBridge(BridgeType bridgeType)
        {
            _selectedType = bridgeType;
            SpawnBridge();
        }
    }
}