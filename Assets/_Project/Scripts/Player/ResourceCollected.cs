namespace Assets.Scripts.Player
{
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Inventory;
    using Reflex.Attributes;
    using UnityEngine;

    public class ResourceCollected : MonoBehaviour
    {
        private IInventory _playerInventory;
        private IResourceService _resourceSpawner;

        [Inject]
        private void Construct(
            IResourceService resourceSpawner,
            IInventory inventory)
        {
            _resourceSpawner = resourceSpawner;
            _playerInventory = inventory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _resourceSpawner.ReturnResource(resource);
                _playerInventory.AddResource(resource);
            }
        }
    }
}