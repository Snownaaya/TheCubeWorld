using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ResourceSpawner : PoolObject<Resource>
{
    private const string Resource = nameof(Resource);
    private const string Pool = nameof(Pool);

    [Header(Resource)]
    [SerializeField] private Resource[] _resource;
    [SerializeField] private int _maxResources = 20;
    [SerializeField] private float _spawnInterval = 0.1f;

    private Dictionary<ResourceType, Resource> _resources;
    private Transform _transform;

    private void Awake()
    {
        _resources = new Dictionary<ResourceType, Resource>()
        {
            {ResourceType.Dirt, _resource[0]},
            {ResourceType.Wood, _resource[1]},
            {ResourceType.Stone, _resource[2]}
        };

        _transform = transform;
    }

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

        if (_resources.TryGetValue(currentGround.ResourceType, out Resource resourcePrefab) == false)
            return;

        for (int i = 0; i < _maxResources; i++)
        {
            int randomPointIndex = Random.Range(0, currentGround.Points.Length);
            Transform spawnPoint = currentGround.Points[randomPointIndex];

            Resource resourceInstance = Pull(resourcePrefab);
            resourceInstance.transform.position = spawnPoint.position;
            resourceInstance.gameObject.SetActive(true);
        }
    }

    public void ReturnResource(Resource resource) =>
        Push(resource);
}