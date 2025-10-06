using Assets.Scripts.Service.Properties;
using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Datas;
using Assets.Scripts.Items;
using UnityEngine;
using System;

namespace Assets.Scripts.Bridge
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private BridgeType _bridgeType;
        [SerializeField] private BridgePart[] _bridgeParts;
        [SerializeField] private BuildingArea _buildingArea;

        [SerializeField] private Material _blueprintMaterial;
        [SerializeField] private Material _invisibleMaterial;

        private NotLimitedProperty<int> _buildedPartsCount = new(0);

        public event Action<ResourceTypes, BridgeType> Completed;

        private void OnValidate()
        {
            _bridgeParts = GetComponentsInChildren<BridgePart>();
            _buildingArea = GetComponentInChildren<BuildingArea>();

            if (_bridgeParts.Length > 0)
                _bridgeParts[0].SetMaterial(_blueprintMaterial);

            for (int i = 1; i < _bridgeParts.Length; i++)
                _bridgeParts[i].SetMaterial(_invisibleMaterial);
        }

        private void OnEnable() =>
            _buildingArea.ResourceDelivered += Build;

        private void OnDisable() =>
            _buildingArea.ResourceDelivered -= Build;

        private void Build(ResourceConfig resource)
        {
            if (_buildedPartsCount.Value >= _bridgeParts.Length)
            {
                Completed?.Invoke(resource.ResourceType, _bridgeType);
                _buildingArea.gameObject.SetActive(false);
                return;
            }

            _bridgeParts[_buildedPartsCount.Value].TryBuild(resource.Material);

            if (_bridgeParts[_buildedPartsCount.Value].IsBuilded)
            {
                _buildedPartsCount.Value++;
                _buildingArea.MoveBarrier();
            }
        }
    }
}