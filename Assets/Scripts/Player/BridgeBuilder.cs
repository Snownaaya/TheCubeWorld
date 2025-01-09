using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Player;

[RequireComponent(typeof(Player))]
public class BridgeBuilder : MonoBehaviour
{
    [SerializeField] private ResourceStorage _storage;
    [SerializeField] private ResourceSpawner _spawner;
    [SerializeField] private LayerMask _bridgeLayer;

    private RaycastHit _hitInfo;

    private Player _player;
    private PlayerInventory _playerInventory;
    private Transform _transform;

    public Vector3 BuildPosition => _hitInfo.point;

    private void Awake()
    {
        _transform = transform;
        _player = GetComponent<Player>();
    }

    public void TryBuild(BridgeData bridgeData)
    {
        if (_hitInfo.transform == null)
            return;

        if (_playerInventory.HasEnoughResource(bridgeData.Resource, 0) == false)
            return;

        var resource = _storage.GetResourceType(bridgeData.Resource);

        if (Physics.Raycast(_transform.position, BuildPosition, _bridgeLayer, (int)QueryTriggerInteraction.Ignore))
        {
        }
    }

    private void Build(BridgeData bridgeData)
    {
        if (_playerInventory.HasEnoughResource(bridgeData.Resource, 0))
        {

        }
    }

    private void OnDrawGizmos()
    {
        if (TryGetComponent(out Bridge bridge))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, bridge.transform.position);
            Gizmos.DrawSphere(bridge.transform.position, 0.5f);
        }
    }
}