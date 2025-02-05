using UnityEngine;

public class PlayerPlatformDetector : MonoBehaviour
{
    [SerializeField] private ResourceSpawner _spawner;

    private Coroutine _coroutine;
    private Ground _currentGround;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
        {
            _currentGround = ground;
            _coroutine = StartCoroutine(_spawner.SpawnRoutine(_currentGround));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}