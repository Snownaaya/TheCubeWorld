using Assets.Scripts.Items;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ResourceMediator : MonoBehaviour
    {
        [SerializeField] private ResourceCountView[] _view;

        private PlayerInventory _playerInventory;

        public void Initialize(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;

            foreach (var resourceType in _playerInventory.ResourceStacks.Keys)
                _playerInventory.ResourceStacks[resourceType].Changed += (value) => UpdateCountText(resourceType, value);
        }

        private void OnDisable()
        {
            if (_playerInventory == null)
                return;
       
            foreach (var resourceType in _playerInventory.ResourceStacks.Keys)
                _playerInventory.ResourceStacks[resourceType].Changed -= (value) => UpdateCountText(resourceType, value);
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