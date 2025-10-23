using Assets.Scripts.Player.Inventory;
using Random = UnityEngine.Random;
using Assets.Scripts.Items;
using Reflex.Attributes;
using UnityEngine;
using System;
using Assets.Scripts.Enemies.Boss.Target;

namespace Assets.Scripts.Player.Attack
{
    public class ResourceConsumer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Resource[] _resourcePrefabs;
        [SerializeField] private ResourceTypes[] _resourceType;
        [SerializeField] private Transform _attackPoint;

        private IResourceStorage _resourceStorage;
        private IInventory _inventory;
        private IBossTargetService _bossTargetService;
        private IResourceService _resourceService;

        [Inject]
        private void Construct(
            IInventory inventory,
            IBossTargetService bossTargetService,
            IResourceService resourceService,
            IResourceStorage resourceStorage)
        {
            _inventory = inventory;
            _bossTargetService = bossTargetService;
            _resourceService = resourceService;
            _resourceStorage = resourceStorage;
        }

        public bool TryConsumeResource()
        {
            ResourceTypes selectedConfig = (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);

            SpawnResource(selectedConfig);
            _inventory.UseResource(selectedConfig);
            _resourceStorage.RemoveResource(selectedConfig, 1);

            return true;
        }

        private void SpawnResource(ResourceTypes resourceType)
        {
            // int prefabIndex = Random.Range(0, _resourcePrefabs.Length);
            int prefabIndex = Array.IndexOf(_resourceType, resourceType);

            Resource resource = _resourcePrefabs[prefabIndex];
            Resource resourcePrefab = _resourceService.Pull(resource);

            resourcePrefab.transform.position = _attackPoint.transform.position;
            resourcePrefab.transform.rotation = _attackPoint.transform.rotation;

            resourcePrefab.PrepareForThrow();

            IBossTarget currentBoss = _bossTargetService.GetCurrentBoss();

            if (currentBoss != null && currentBoss.IsValidTarget())
                resourcePrefab.MovePosition(currentBoss.GetTarget());

            resourcePrefab.Release();
        }
    }
}