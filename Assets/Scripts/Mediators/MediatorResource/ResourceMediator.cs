using Assets.Scripts.Items;
using Assets.Scripts.Player.Inventory;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Domain.MediatorResource
{
    public class ResourceMediator : MonoBehaviour
    {
        [SerializeField] private ResourceCountView[] _view;

        private IInventory _playerInventory;
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [Inject]
        private void Construct(IInventory inventory)
        {
            _playerInventory = inventory;

            foreach (ResourceTypes resourceType in _playerInventory.ResourceStacks.Keys)
            {
                UpdateCountText(resourceType, _playerInventory.ResourceStacks[resourceType].Value);

                _playerInventory.ResourceStacks[resourceType]
                        .Subscribe(value => UpdateCountText(resourceType, value))
                        .AddTo(_compositeDisposable);
            }
        }

        private void OnDisable()
        {
            if (_playerInventory == null)
                return;

            _compositeDisposable.Dispose();
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