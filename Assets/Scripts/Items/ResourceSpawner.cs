using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ResourceSpawner : PoolObject<Resource>, IPlaceable
{
    private const string Resource = nameof(Resource);
    private const string Pool = nameof(Pool);

    [Header(Resource)]
    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private List<Ground> _ground = new List<Ground>();
    [SerializeField] private int _maxResources = 19;
    [SerializeField] private float _delay;

    private Transform _transform;

    private void OnValidate()
    {
        if (_resources.Count == 0)
            return;

        if (_ground.Count == 0)
            return;
    }

    private void Awake() =>
        _transform = transform;

    private void Start() =>
        StartCoroutine(SpawnRoutine());

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            SpawnResource();
            yield return new WaitUntil(() => GetActiveCount() <= _maxResources);
            yield return wait;
        }
    }

    public void SpawnResource()
    {
        var resourcePrefab = _resources[Random.Range(0, _resources.Count)];
        var resource = Pull(resourcePrefab);
        var randomGround = _ground[Random.Range(0, _ground.Count)];
        resource.transform.position = randomGround.GetRandomPosition();
    }

    public void ReturnCube(Resource resource) =>
        Push(resource);
}