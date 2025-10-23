using Assets.Scripts.Particles;
using Assets.Scripts.Service.AchievementServices;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;

        private Bridge _currentBridge;
        private BridgeTrackerService _trackerService;
        private BridgeType _selectedType = BridgeType.Easy;
        private IParticleSpawner _bridgeEffect;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

        [Inject]
        private void Construct(IParticleSpawner particleSpawner, BridgeTrackerService bridgeTracker)
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

            _bridgeEffect.Initialize(transform);
            _currentBridge = _factory.Get(_selectedType, _point.position);
            _trackerService.Register(_currentBridge);
            _bridgeEffect.SpawnParticle(ParticleTypes.BridgeBuild, transform);
        }

        public void SelectBridge(BridgeType bridgeType)
        {
            _selectedType = bridgeType;
            SpawnBridge();
        }
    }
}