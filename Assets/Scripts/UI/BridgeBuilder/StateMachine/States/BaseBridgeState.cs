using Assets.Scripts.UI.BridgeBuilder;
using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Bridge;
using Assets.Scripts.Datas;
using Assets.Scripts.Items;
using Assets.Scripts.Utils;
using System.Linq;

public abstract class BaseBridgeState : IStates
{
    private BuildButton _buildButton;
    private ISwitcher _stateSwitcher;
    private Bridge _currentBridge;
    private int _resourceCost = 1;

    public BaseBridgeState(ISwitcher switcher, BuildButton buildButton)
    {
        _buildButton = buildButton;
        _stateSwitcher = switcher;
    }

    public BuildButton BuildButton => _buildButton;
    public ISwitcher StateSwitcher => _stateSwitcher;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public void DeliverResourceToBridge(ResourceTypes resourceType)
    {
        BridgeSpawner currentSpawner = BuildButton.SpawnerSelector.GetCurrentSpawner();
        Bridge bridge = currentSpawner.CurrentBridge;
        BuildingArea buildingArea = bridge.GetComponentInChildren<BuildingArea>();

        if (buildingArea == null)
            return;

        ResourceConfig selectedConfig = BuildButton.ResourceConfig
            .FirstOrDefault(config => config.ResourceType == resourceType);

        if (BuildButton.Inventory.HasResource(selectedConfig.ResourceType, new NotLessZeroProperty<int>(_resourceCost)))
        {
            BuildButton.Inventory.UseResource(selectedConfig.ResourceType);
            BuildButton.ResourceStorage.RemoveResource(selectedConfig.ResourceType, 1);

            if (selectedConfig != null)
                buildingArea.DeliveResource(selectedConfig);
        }
    }
}