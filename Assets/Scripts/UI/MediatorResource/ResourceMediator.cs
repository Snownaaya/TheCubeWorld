using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceMediator : MonoBehaviour
    {
        [SerializeField] private ResourceCountView[] _view;

        private IInventory _playerInventory;

        [Inject]
        private void Construct(IInventory inventory) =>
            _playerInventory = inventory;

        public void Initialize(IInventory playerInventory)
        {
            _playerInventory = playerInventory;

            foreach (ResourceType resourceType in _playerInventory.ResourceStacks.Keys)
            {
                _playerInventory.ResourceStacks[resourceType].Changed += (value) => UpdateCountText(resourceType, value);

            }
        }

        private void OnDisable()
        {
            if (_playerInventory == null)
                return;
       
            foreach (ResourceType resourceType in _playerInventory.ResourceStacks.Keys)
            {
                _playerInventory.ResourceStacks[resourceType].Changed -= (value) => UpdateCountText(resourceType, value);

            }
        }

        public void UpdateCountText(ResourceType type, int count)
        {
            foreach (ResourceCountView view in _view)
            {
                if (view.Config.ResourceType == type)
                    view.UpdateText(count);
            }
        }
    }
}