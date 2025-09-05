using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Items;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class ResourceCollected : MonoBehaviour
    {
        private IResourceStorage _resourceStorage;
        private IInventory _playerInventory;
        private IResourceService _resourceSpawner;

        [Inject]
        private void Construct(IResourceStorage resourceStorage, IResourceService resourceSpawner,IInventory inventory)
        {
            _resourceStorage = resourceStorage;
            _resourceSpawner = resourceSpawner;
            _playerInventory = inventory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                resource.PrepareForCollection();
                _resourceStorage.AddResource(resource);
                _resourceSpawner.ReturnResource(resource);
                _playerInventory.AddResource(resource);
            }
        }
    }
}