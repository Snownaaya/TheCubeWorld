using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.Items;
using Assets.Scripts.Player;

public class ResourceCollected : MonoBehaviour
{
    [SerializeField] private ResourceStorage _resourceStorage;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private ResourceMediator _resourceMediator;

    private void Awake()
    {
        _inventory = new PlayerInventory();
        _resourceMediator.Initialize(_inventory);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            _resourceStorage.AddResource(resource);
            _resourceSpawner.ReturnResource(resource);
            _inventory.CollectResource(resource);
        }
    }
}