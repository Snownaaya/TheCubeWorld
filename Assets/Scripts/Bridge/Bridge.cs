using Assets.Scripts.Datas;
using UnityEngine;

namespace Assets.Scripts.Bridge
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private BridgePart[] _bridgeParts;
        [SerializeField] private BuildingArea _buildingArea;

        [SerializeField] private Material _blueprintMaterial;
        [SerializeField] private Material _invisibleMaterial;

        private int _buildedPartsCount = 0;

        public BridgePart BridgeParts => GetComponentInChildren<BridgePart>();

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
            _buildingArea.ResourceDelivered += Build;

        private void Build(ResourceConfig resource)
        {
            _bridgeParts[_buildedPartsCount].TryBuild(resource.Material);

            if (_bridgeParts[_buildedPartsCount].IsBuilded)
            {
                _buildedPartsCount++;
                _buildingArea.MoveBarrier();

                if (_bridgeParts[_buildedPartsCount].IsBuilded)
                {
                    Debug.LogError("При попытке достроить блок в деталь");
                }
            }
        }
    }
}