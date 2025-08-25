using Assets.Scripts.Particles;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;

        private Bridge _currentBridge;
        private BridgeType _selectedType = BridgeType.Easy;
        private IParticleSpawner _bridgeEffect;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

        [Inject]
        private void Construct(IParticleSpawner particleSpawner) =>
            _bridgeEffect = particleSpawner;

        public void SpawnBridge()
        {
            if (_currentBridge != null)
                Destroy(_currentBridge.gameObject);

            _bridgeEffect.Initialize(transform);
            _currentBridge = _factory.Get(_selectedType, _point.position);
            _bridgeEffect.SpawnParticle(ParticleTypes.BridgeBuild, transform);
        }

        public void SelectBridge(BridgeType bridgeType)
        {
            _selectedType = bridgeType;
            SpawnBridge();
        }
    }
}