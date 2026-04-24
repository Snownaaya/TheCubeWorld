using System.Linq;
using Assets.Scripts.Bridge;
using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Datas;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.UI.BridgeBuilder;
using UniRx;

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

        if (BuildButton.Inventory.HasResource(selectedConfig.ResourceType, _resourceCost))
        {
            buildingArea.DeliveResource(selectedConfig);
            BuildButton.Inventory.UseResource(selectedConfig.ResourceType);
        }
    }
}