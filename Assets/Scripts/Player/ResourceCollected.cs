using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Player;

public class ResourceCollected : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            resource.PickUp();
            _resourceStorage.AddResource(resource);
            _resourceSpawner.ReturnResource(resource);
            _inventory.CollectResource(resource, _resourceStorage);
        }
    }
}