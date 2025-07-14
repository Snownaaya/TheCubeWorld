using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts.Bridge.Factory
{
    public class BridgeSpawner : MonoBehaviour
    {
        [SerializeField] private BridgeFactory _factory;
        [SerializeField] private Transform _point;
        [SerializeField] private ParticleSpawner _bridgeEffect;

        private Bridge _currentBridge;
        private BridgeType _selectedType = BridgeType.Easy;

        public Transform Point => _point;
        public Bridge CurrentBridge => _currentBridge;

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