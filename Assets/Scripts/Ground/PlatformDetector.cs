using Assets.Scripts.Ground;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Reflex.Attributes;
using System.Threading;
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
            _currentGround.ResetPoints();
            _cancellationTokenSource = new CancellationTokenSource();
            _spawner.SpawnRoutine(_currentGround, _cancellationTokenSource.Token);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _spawner.ReturnAllPool();
            _spawner.ActiveResources.Clear();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
