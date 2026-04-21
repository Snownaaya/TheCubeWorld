namespace Assets._Project.Scripts.Items
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Assets.Scripts.Ground;
    using Assets.Scripts.Items;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class ResourceSpawner : PoolObject<Resource>, IResourceService
    {
        [SerializeField] private Resource[] _resource;
        [SerializeField] private int _maxResources = 16;
        [SerializeField] private float _delay;

        private readonly List<Resource> _activeResources = new ();
        private Ground _currentGround;
        private Dictionary<ResourceTypes, Resource> _resources;

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
            Clear();

            while (cancellationToken.IsCancellationRequested == false)
            {
                _currentGround = currentGround;

                SpawnResource(currentGround);

                await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken,
                                    delayType: DelayType.UnscaledDeltaTime);
            }
        }

        public void ReturnResource(Resource resource)
        {
            _activeResources.Remove(resource);

            if (resource.SpawnPoint != null && _currentGround != null)
                _currentGround.ReturnPoint(resource.SpawnPoint);

            Push(resource);
        }

        public void Clear()
        {
            for (int i = _activeResources.Count - 1; i >= 0; i--)
            {
                Resource resource = _activeResources[i];

                if (resource == null)
                {
                    _activeResources.RemoveAt(i);
                    continue;
                }

                if (resource.SpawnPoint != null && _currentGround != null)
                    _currentGround.ReturnPoint(resource.SpawnPoint);

                Push(resource);
            }

            _activeResources.Clear();
        }

        private void SpawnResource(Ground currentGround)
        {
            int spawnCount = Mathf.Min(_maxResources - _activeResources.Count, currentGround.AvailableCount);

            if (spawnCount <= 0)
                return;

            for (int i = 0; i < spawnCount; i++)
            {
                Transform spawnPoint = currentGround.GetPoint();

                int randomPrefab = Random.Range(0, _resource.Length);
                Resource resourcePrefab = _resource[randomPrefab];

                Resource resourceInstance = Pull(resourcePrefab);
                resourceInstance.SetSpawnPoint(spawnPoint);

                resourceInstance.transform.position = spawnPoint.position;

                _activeResources.Add(resourceInstance);
            }
        }
    }
}