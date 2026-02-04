using UnityEngine;

namespace Assets.Scripts.Bridge
{
    public class BridgeBlock : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

#if UNITY_EDITOR
        private void OnValidate() =>
            _renderer = GetComponent<Renderer>();
#endif

        public void SetMaterial(Material material) =>
            _renderer.material = material;
    }
}