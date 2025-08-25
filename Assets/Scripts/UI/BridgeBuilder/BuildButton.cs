using Assets.Scripts.Datas;
using Assets.Scripts.Other;
using Reflex.Attributes;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Items;

namespace Assets.Scripts.UI.BridgeBuilder
{
    public class BuildButton : MonoBehaviour
    {
        [field: SerializeField] public ResourceConfig[] ResourceConfig { get; private set; }
        [field: SerializeField] public SpawnerSelector SpawnerSelector { get; private set; }
        [field: SerializeField] public Button DirtButton { get; private set; }
        [field: SerializeField] public Button WoodButton { get; private set; }
        [field: SerializeField] public Button StoneButton { get; private set; }

        private IResourceStorage _resourceStorage;
        private IInventory _inventory;
        private BuildBridgeState _state;

        private void Awake() =>
            _state = new BuildBridgeState(this);

        [Inject]
        private void Construct(IResourceStorage resourceStorage, IInventory inventory)
        {
            _resourceStorage = resourceStorage;
            _inventory = inventory;
        }

        public IResourceStorage ResourceStorage => _resourceStorage;
        public IInventory Inventory => _inventory;
        public BuildBridgeState State => _state;

        protected void OnEnable()
        {
            DirtButton.onClick.AddListener(OnDirtButtonClick);
            WoodButton.onClick.AddListener(OnWoodButtonClick);
            StoneButton.onClick.AddListener(OnStoneButtonClick);
        }

        protected void OnDisable()
        {
            DirtButton.onClick.RemoveListener(OnDirtButtonClick);
            WoodButton.onClick.RemoveListener(OnWoodButtonClick);
            StoneButton.onClick.RemoveListener(OnStoneButtonClick);
        }

        private void OnDirtButtonClick() =>
            State.SwitchState<DirtSelectedState>();

        private void OnWoodButtonClick() =>
            State.SwitchState<WoodSelectedState>();

        private void OnStoneButtonClick() =>
            State.SwitchState<StoneSelectedState>();
    }
}