using Assets.Scripts.Items;
using Assets.Scripts.Player.Inventory;
using Reflex.Attributes;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceMediator : MonoBehaviour
    {
        [SerializeField] private ResourceCountView[] _view;

        private IInventory _playerInventory;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _playerInventory = inventory;

            foreach (ResourceTypes resourceType in _playerInventory.ResourceStacks.Keys)
            {
                _playerInventory.ResourceStacks[resourceType].Changed += (value) => UpdateCountText(resourceType, value);
                UpdateCountText(resourceType, _playerInventory.ResourceStacks[resourceType].Value);
            }
        }

        private void OnDisable()
        {
            if (_playerInventory == null)
                return;
       
            foreach (ResourceTypes resourceType in _playerInventory.ResourceStacks.Keys)
            {
                _playerInventory.ResourceStacks[resourceType].Changed -= (value) => UpdateCountText(resourceType, value);

            }
        }

        public void UpdateCountText(ResourceTypes type, int count)
        {
            foreach (ResourceCountView view in _view)
            {
                if (view.Config.ResourceType == type)
                    view.UpdateText(count);
            }
        }
    }
}