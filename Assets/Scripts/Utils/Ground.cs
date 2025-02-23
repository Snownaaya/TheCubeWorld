using UnityEngine;
using Assets.Scripts.Items;

public class Ground : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private ResourceType _resourceType;

    public Transform[] Points => _points;
    public ResourceType ResourceType => _resourceType;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _points = new Transform[pointCount];

        for (int i = 0; i < pointCount; i++)
            _points[i] = transform.GetChild(i);
    }
#endif
}