using UnityEngine;
using Assets.Scripts.Items;

public class Bridge : MonoBehaviour
{
    private ResourceStorage _resourceStorage;
    private Transform _bridgePivot;

    private Vector3 _originalPosition;
    private Vector3 _originalScale;

    private int _scaleHeight;

    public  int Amount { get; private set; }
    public  bool IsBuilding { get; private set; }
    public float BuildProgress { get; private set; }

    //public void Build(BridgeData bridgeData, Vector3 position, int resourceCount)
    //{
    //    if (resourceCount == Amount && IsBuilding == false)
    //    {
    //        Vector3 newScale = _bridgePivot.localScale;
    //        newScale.z += resourceCount * _scaleHeight;
    //        _bridgePivot.localScale = newScale;
    //    }
    //}

    public void Reset()
    {

    }
}