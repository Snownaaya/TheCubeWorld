using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Ground
{
    [RequireComponent(typeof(Ground))]
    public class PlatformDetector : MonoBehaviour
    {
        [SerializeField] private ResourceSpawner _spawner;

        private Coroutine _coroutine;
        private Ground _currentGround;

        private void Awake() =>
            _currentGround = GetComponent<Ground>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _coroutine = StartCoroutine(_spawner.SpawnRoutine(_currentGround));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                    _spawner.ClearPool();
                    _coroutine = null;
                }
            }
        }
    }
}