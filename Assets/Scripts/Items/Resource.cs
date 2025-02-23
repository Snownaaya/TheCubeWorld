using UnityEngine;
using Assets.Scripts.Items;

[RequireComponent(typeof(Collider))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;

    private Transform _transform;
    private GameObject _gameObject;

    public ResourceType ResourceType => _resourceType;
    public int Amount { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
    }

    public void PickUp() =>
        _gameObject.SetActive(false);

    public void Release() =>
        _gameObject.SetActive(true);
}