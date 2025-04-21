using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ResourceSpawner : PoolObject<Resource>
{
    private const string Resource = nameof(Resource);
    private const string Pool = nameof(Pool);

    [SerializeField] private AnimationCurve _spawnProbability;

    [Header(Resource)]
    [SerializeField] private Resource[] _resource;
    [SerializeField] private int _maxResources = 20;
    [SerializeField] private float _spawnInterval = 2f;

    private Dictionary<ResourceType, Resource> _resources = new Dictionary<ResourceType, Resource>();
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
            currentGround.ResetPoints();
            SpawnResource(currentGround);
            yield return new WaitForSeconds(_spawnInterval);
            yield return new WaitUntil(() => GetActiveCount() == 0);
        }
    }

    private void SpawnResource(Ground currentGround)
    {
        if (_resources.Count == 0 || currentGround == null || currentGround.Points == null || currentGround.Points.Count == 0)
            return;

        int spawnCount = Mathf.Min(_maxResources - GetActiveCount(), currentGround.Points.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            Transform spawnPoint = currentGround.GetRandomPoint();

            int randomPrefab = Random.Range(0, _resources.Count);
            Resource resourcePrefab = _resource[randomPrefab];

            Resource resourceInstance = Pull(resourcePrefab);
            resourceInstance.transform.position = spawnPoint.position;
            resourceInstance.gameObject.SetActive(true);
        }
    }

    public void ReturnResource(Resource resource) =>
        Push(resource);

    private void Reset() =>
        ClearPool();
}