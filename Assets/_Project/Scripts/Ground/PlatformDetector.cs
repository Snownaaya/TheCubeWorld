using System.Threading;
using Assets.Scripts.Ground;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;

[RequireComponent(typeof(Ground))]
public class PlatformDetector : MonoBehaviour
{
    private IResourceService _spawner;
    private Ground _currentGround;
    private CancellationTokenSource _cancellationTokenSource;

    [Inject]
    private void Construct(IResourceService resourceSpawner) =>
        _spawner = resourceSpawner;

    private void Start() =>
        _currentGround = GetComponent<Ground>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            _spawner.SpawnRoutine(_currentGround, _cancellationTokenSource.Token).Forget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
            _spawner.Clear();
        }
    }

    private void OnDestroy() =>
        _cancellationTokenSource?.Cancel();
}