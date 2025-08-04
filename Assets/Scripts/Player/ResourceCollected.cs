using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.Interfaces;
using Reflex.Attributes;
using Assets.Scripts.Player.Inventory;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Character))]
    public class ResourceCollected : MonoBehaviour
    {
        [SerializeField] private ResourceSpawner _resourceSpawner;
        //[SerializeField] private ResourceMediator _resourceMediator;

        private Character _character;
        private IResourceStorage _resourceStorage;
        private IInventory _playerInventory;

        [Inject]
        private void Construct(IResourceStorage resourceStorage, IInventory inventory)
        {
            _resourceStorage = resourceStorage;
            _playerInventory = inventory;
        }

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                resource.PrepareForCollection();
                // _resourceMediator.Initialize(_playerInventory);
                _resourceStorage.AddResource(resource);
                _resourceSpawner.ReturnResource(resource);
                _playerInventory.AddResource(resource);
            }
        }
    }
}