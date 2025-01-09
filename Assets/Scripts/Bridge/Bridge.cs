using Assets.Scripts.Items;
using UnityEngine;

public abstract class Bridge : MonoBehaviour
{
    private ResourceStorage _resourceStorage;

    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    private Material _material;

    private Transform _bridgePivot;
    private int _scaleHeight;

    public abstract int Amount { get; }
    public abstract bool IsBuilding { get; }
    public abstract float BuildProgress { get; }
    public virtual Material Material { get; }

    public virtual void Build(BridgeData bridgeData, Vector3 position, int resourceCount)
    {
        if (resourceCount == Amount && IsBuilding == false)
        {
            Vector3 newScale = _bridgePivot.localScale;
            newScale.z += resourceCount * _scaleHeight;
            _bridgePivot.localScale = newScale;
        }
    }

    public abstract void Initialized(ResourceStorage resourceStorage, Vector3 position);

    public virtual void Reset() { }
}