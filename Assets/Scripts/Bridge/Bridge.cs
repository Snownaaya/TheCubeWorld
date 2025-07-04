using Assets.Scripts.Datas;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Properties;
using System;
using UnityEngine;

namespace Assets.Scripts.Bridge
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private BridgePart[] _bridgeParts;
        [SerializeField] private BuildingArea _buildingArea;

        [SerializeField] private Material _blueprintMaterial;
        [SerializeField] private Material _invisibleMaterial;

        private NotLimitedProperty<int> _buildedPartsCount = new(0);

        public event Action OnBridgeCompleted;

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
                _buildingArea.gameObject.SetActive(false);
                OnBridgeCompleted.Invoke();
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