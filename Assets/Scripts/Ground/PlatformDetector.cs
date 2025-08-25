using Assets.Scripts.Ground;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Assets.Scripts.Service.ReflexService;
using Reflex.Attributes;
using Reflex.Core;
using UnityEngine;

[RequireComponent(typeof(Ground))]
public class PlatformDetector : MonoBehaviour
{
    private IResourceService _spawner;
    private Ground _currentGround;
    private Coroutine _coroutine;
    private Container _container;

    [Inject]
    private void Construct(IResourceService resourceSpawner) =>
        _spawner = resourceSpawner;

    private void Start()
    {
        _currentGround = GetComponent<Ground>();
        //_spawner = _container.Resolve<IResourceService>();

        if (_spawner == null)
            Debug.LogError("Spawner is null in " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _coroutine = StartCoroutine(_spawner.SpawnRoutine(_currentGround));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character character) && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _spawner.ClearPool();
            _coroutine = null;
        }
    }
}
