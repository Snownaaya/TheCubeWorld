using UnityEngine;

namespace Assets.Scripts.Bridge
{
    public class BridgePart : MonoBehaviour
    {
        [SerializeField] private BridgeBlock[] _bridgeBlocks;

        private int _buildedBlocksCount = 0;

        public bool IsBuilded => _buildedBlocksCount == _bridgeBlocks.Length;

        private void OnValidate()
        {
            _bridgeBlocks = GetComponentsInChildren<BridgeBlock>();
        }

        public void TryBuild(Material material)
        {
            _bridgeBlocks[_buildedBlocksCount++].SetMaterial(material);
        }

        public void SetMaterial(Material material)
        {
            foreach (BridgeBlock block in _bridgeBlocks)
                block.SetMaterial(material);
        }
    }
}