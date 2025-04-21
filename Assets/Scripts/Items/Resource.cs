using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Datas;

[RequireComponent(typeof(Collider))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    private ResourceType _resourceType;
    private GameObject _gameObject;
    private Material _material;

    private void Awake()
    {
        _resourceType = _config.ResourceType;
        _gameObject = gameObject;
        _material = GetComponent<Renderer>().material;
    }

    public ResourceType ResourceType => _resourceType;
    public ResourceConfig Config => _config;
    public Material Material => _material;

    public void PickUp() =>
        _gameObject.SetActive(false);

    public void Release() =>
        _gameObject.SetActive(true);
}