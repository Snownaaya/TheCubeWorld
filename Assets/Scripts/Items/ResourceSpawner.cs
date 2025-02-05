using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceSpawner : PoolObject<Resource>
{
    private const string Resource = nameof(Resource);
    private const string Pool = nameof(Pool);

    [Header(Resource)]
    [SerializeField] private List<Resource> _resources = new List<Resource>();
    [SerializeField] private int _maxResources = 20;
    [SerializeField] private float _spawnInterval = 0.1f;

    private Transform _transform;

    private void OnValidate()
    {
        if (_resources.Count == 0)
            return;
    }

    private void Awake() =>
        _transform = transform;

    public IEnumerator SpawnRoutine(Ground currentGround)
    {
        while (enabled)
        {
            SpawnResource(currentGround);
            yield return new WaitForSeconds(_spawnInterval);
            yield return new WaitUntil(() => GetActiveCount() >= _maxResources);
        }
    }

    private void SpawnResource(Ground currentGround)
    {
        if (_resources.Count == 0 || currentGround == null || currentGround.Points == null || currentGround.Points.Length == 0)
            return;

        for (int i = 0; i < _maxResources; i++)
        {
            int randomPointIndex = Random.Range(0, currentGround.Points.Length);
            Transform spawnPoint = currentGround.Points[randomPointIndex];

            Resource resourcePrefab = _resources[Random.Range(0, _resources.Count)];
            resourcePrefab = Pull(resourcePrefab);
            resourcePrefab.transform.position = spawnPoint.position;
        }
    }

    public void ReturnResource(Resource resource) =>
        Push(resource);
}