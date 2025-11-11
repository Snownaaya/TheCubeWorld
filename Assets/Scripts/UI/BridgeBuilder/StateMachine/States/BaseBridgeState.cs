using Assets.Scripts.Service.Properties;
using Assets.Scripts.UI.BridgeBuilder;
using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Bridge;
using Assets.Scripts.Datas;
using Assets.Scripts.Items;
using System.Linq;

public abstract class BaseBridgeState : IStates
{
    private BuildButton _buildButton;

    private int _resourceCost = 1;

    public BaseBridgeState(BuildButton buildButton)
    {
        _buildButton = buildButton;
    }

    public BuildButton BuildButton => _buildButton;

    public virtual void Enter() { }
    public virtual void Exit() { }

    public void DeliverResourceToBridge(ResourceTypes resourceType)
    {
        BridgeSpawner currentSpawner = BuildButton.SpawnerSelector.GetCurrentSpawner();
        Bridge bridge = currentSpawner.CurrentBridge;
        BuildingArea buildingArea = bridge.GetComponentInChildren<BuildingArea>();

        if (buildingArea == null && bridge == null && currentSpawner == null)
            return;

        ResourceConfig selectedConfig = BuildButton.ResourceConfig
            .FirstOrDefault(config => config.ResourceType == resourceType);

        if (BuildButton.Inventory.HasResource(selectedConfig.ResourceType, new NotLimitedProperty<int>(_resourceCost)))
        {
            BuildButton.Inventory.UseResource(selectedConfig.ResourceType);
           // BuildButton.ResourceStorage.RemoveResource(selectedConfig.ResourceType, 1);

            if (selectedConfig != null)
                buildingArea.DeliveResource(selectedConfig);
        }
    }
}