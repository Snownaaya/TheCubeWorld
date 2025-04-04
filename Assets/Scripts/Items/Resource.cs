using UnityEngine;
using Assets.Scripts.Items;

[RequireComponent(typeof(Collider))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;

    private Transform _transform;
    private GameObject _gameObject;
    private Material _material;

    public ResourceType ResourceType => _resourceType;
    public Material Material => _material;

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
        _material = GetComponent<Renderer>().material;
    }

    public void PickUp() =>
        _gameObject.SetActive(false);

    public void Release() =>
        _gameObject.SetActive(true);
}