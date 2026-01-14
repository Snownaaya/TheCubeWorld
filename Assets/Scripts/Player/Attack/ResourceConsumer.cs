using Assets.Scripts.Enemies.Boss.Target;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Items;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;
using UniRx;

namespace Assets.Scripts.Player.Attack
{
    public class ResourceConsumer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Resource[] _resourcePrefabs;
        [SerializeField] private ResourceTypes[] _resourceType;
        [SerializeField] private Transform _attackPoint;

        private IInventory _inventory;
        private IBossTargetService _bossTargetService;
        private IResourceService _resourceService;

        [Inject]
        private void Construct(
            IInventory inventory,
            IBossTargetService bossTargetService,
            IResourceService resourceService)
        {
            _inventory = inventory;
            _bossTargetService = bossTargetService;
            _resourceService = resourceService;
        }

        public bool TryConsumeResource()
        {
            SpawnResource(ResourceTypeSelector.GetRandomTypes());
            _inventory.UseResource(ResourceTypeSelector.GetRandomTypes());
            return true;
        }

        public bool HasEnoughTotalResources(int requiredAmount)
        {
            int total = _inventory.GetTotalResourcesAmount();
            return total >= requiredAmount;
        }

        private void SpawnResource(ResourceTypes resourceType)
        {
            if (_resourceService.ActiveResources.Count >= 16)
                return;

            int prefabIndex = Random.Range(0, _resourcePrefabs.Length);
            Resource resource = _resourcePrefabs[prefabIndex];

            Resource resourcePrefab = _resourceService.Pull(resource);

            resourcePrefab.transform.position = GetPosition(resourcePrefab);
            MoveToBossTarget(resourcePrefab);
        }

        private Vector3 GetPosition(Resource resource)
        {
            resource.transform.position = _attackPoint.transform.position;
            resource.transform.rotation = _attackPoint.transform.rotation;

            return resource.transform.position;
        }

        private void MoveToBossTarget(Resource resource)
        {
            IBossTarget currentBoss = _bossTargetService.GetCurrentBoss();

            if (currentBoss != null && currentBoss.IsValidTarget())
                resource.MovePosition(currentBoss.GetTarget());
        }
    }
}