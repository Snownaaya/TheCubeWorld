using UnityEngine;

public class BridgeBlock : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private void OnValidate()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetMaterial(Material material)
    {
        _renderer.material = material;
    }
}