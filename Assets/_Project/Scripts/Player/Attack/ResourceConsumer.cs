namespace Assets.Scripts.Player.Attack
{
    using Assets.Scripts.Enemies.Boss.Target;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Inventory;
    using Reflex.Attributes;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class ResourceConsumer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Resource[] _resourcePrefabs;
        [SerializeField] private ResourceTypes[] _resourceType;
        [SerializeField] private Transform _attackPoint;

        private IInventory _inventory;
        private IBossTargetService _bossTargetService;

        [Inject]
        private void Construct(
            IInventory inventory,
            IBossTargetService bossTargetService)
        {
            _inventory = inventory;
            _bossTargetService = bossTargetService;
        }

        public bool TryConsumeResource()
        {
            if (HasEnoughTotalResources(1) == false)
                return false;

            ResourceTypes type = ResourceTypeSelector.GetRandomTypes();

            SpawnResource(type);
            _inventory.UseResource(type);
            return true;
        }

        public bool HasEnoughTotalResources(int requiredAmount)
        {
            int total = _inventory.GetTotalResourcesAmount();
            return total >= requiredAmount;
        }

        private void SpawnResource(ResourceTypes resourceType)
        {
            int prefabIndex = Random.Range(0, _resourcePrefabs.Length);
            Resource resource = _resourcePrefabs[prefabIndex];

            Resource resourcePrefab = Instantiate(resource);

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