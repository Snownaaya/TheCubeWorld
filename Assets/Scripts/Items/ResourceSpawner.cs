using Assets.Scripts.Ground;
using Assets.Scripts.Items;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceSpawner : PoolObject<Resource>, IResourceService
{
    [SerializeField] private Resource[] _resource;
    [SerializeField] private int _maxResources = 16;

    private Ground _currentGround;
    private float _delay = 1.5f;

    private Dictionary<ResourceTypes, Resource> _resources = new Dictionary<ResourceTypes, Resource>();
    private readonly List<Resource> _activeResources = new();

    public List<Resource> ActiveResources => _activeResources;

    private void Awake()
    {
        _resources = new Dictionary<ResourceTypes, Resource>()
        {
            {ResourceTypes.Dirt, _resource[0]},
            {ResourceTypes.Wood, _resource[1]},
            {ResourceTypes.Stone, _resource[2]}
        };
    }

    public async UniTask SpawnRoutine(Ground currentGround, CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested == false)
        {
            _currentGround = currentGround;
            SpawnResource(currentGround);

            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
        }
    }

    private void SpawnResource(Ground currentGround)
    {
        if (_resources.Count == 0 || 
            currentGround == null || 
            currentGround.AvailableCount == 0)
            return;

        int spawnCount = Mathf.Min(_maxResources - _activeResources.Count, currentGround.AvailableCount);

        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = currentGround.GetRandomPoint();

            int randomPrefab = Random.Range(0, _resources.Count);
            Resource resourcePrefab = _resource[randomPrefab];

            Resource resourceInstance = Pull(resourcePrefab);
            resourceInstance.SetSpawnPoint(spawnPoint);
            resourceInstance.transform.position = spawnPoint.position;

            _activeResources.Add(resourceInstance);
        }
    }

    public void ReturnResource(Resource resource)
    {
        if (_activeResources.Contains(resource) == false)
            return;

        _activeResources.Remove(resource);

        if (resource.SpawnPoint != null && _currentGround != null)
            _currentGround.ReturnPoint(resource.SpawnPoint);

        Push(resource);
    }

    public void Clear()
    {
        foreach (Resource resource in _activeResources)
            Push(resource);

        _activeResources.Clear();
        _currentGround.ResetPoints();
    }
}