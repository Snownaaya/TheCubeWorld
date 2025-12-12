using Assets.Scripts.Ground;
using Assets.Scripts.Items;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class ResourceSpawner : PoolObject<Resource>, IResourceService
{
    [SerializeField] private Resource[] _resource;
    [SerializeField] private int _maxResources = 16;

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
            currentGround.ResetPoints();

            SpawnResource(currentGround);
            await UniTask.WaitUntil(() => _activeResources.Count < _maxResources, cancellationToken: cancellationToken);
        }
    }

    private void SpawnResource(Ground currentGround)
    {
        if (_resources.Count == 0 || currentGround == null || currentGround.Points == null || currentGround.Points.Count == 0)
            return;

        int spawnCount = Mathf.Max(_maxResources - _activeResources.Count, currentGround.Points.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = currentGround.GetRandomPoint();

            int randomPrefab = Random.Range(0, _resources.Count);
            Resource resourcePrefab = _resource[randomPrefab];

            Resource resourceInstance = Pull(resourcePrefab);
            resourceInstance.transform.position = spawnPoint.position;

            _activeResources.Add(resourceInstance);
        }
    }

    public void ReturnResource(Resource resource)
    {
        if (_activeResources.Contains(resource))
            _activeResources.Remove(resource);

        Push(resource);
    }

    public void ReturnAllPool()
    {
        for (int i = 0; i < _activeResources.Count; i++)
        {
            Resource resource = _activeResources[i];
            Push(resource);
        }
    }
}