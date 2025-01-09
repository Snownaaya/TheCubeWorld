using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Player;

public class ResourceCollected : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;

    [SerializeField] private PlayerInventory _playerCollector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            resource.PickUp();
            _playerCollector.CollectResource(resource);
            _resourceStorage.AddResource(resource);
        }
    }
}