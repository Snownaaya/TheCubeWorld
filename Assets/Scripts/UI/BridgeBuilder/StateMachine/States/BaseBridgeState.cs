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

    public BaseBridgeState(BuildButton buildButton) =>
        _buildButton = buildButton;

    public BuildButton BuildButton => _buildButton;

    public virtual void Enter() { }
    public virtual void Exit() { }

    public void DeliverResourceToBridge(ResourceTypes resourceType)
    {
        BridgeSpawner currentSpawner = BuildButton.SpawnerSelector.GetCurrentSpawner();

        if (currentSpawner == null)
            return;

        Bridge bridge = currentSpawner.CurrentBridge;

        if (bridge == null)
            return;

        BuildingArea buildingArea = bridge.GetComponentInChildren<BuildingArea>();

        if (buildingArea == null)
            return;

        ResourceConfig selectedConfig = BuildButton.ResourceConfig
            .FirstOrDefault(config => config.ResourceType == resourceType);

        if (selectedConfig == null)
            return;

        if (BuildButton.Inventory.HasResource(selectedConfig.ResourceType, new NotLimitedProperty<int>(_resourceCost)))
        {
            BuildButton.Inventory.UseResource(selectedConfig.ResourceType);
            buildingArea.DeliveResource(selectedConfig);
        }
    }
}