using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Datas;

[RequireComponent(typeof(Collider))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    private ResourceType _resourceType;
    private Material _material;

    private void Awake()
    {
        _resourceType = _config.ResourceType;
        _material = GetComponent<Renderer>().material;
    }

    public ResourceType ResourceType => _resourceType;

    public void PickUp() =>
        gameObject.SetActive(false);

    public void Release() =>
        gameObject.SetActive(true);
}