using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Resource : MonoBehaviour
{
    private Collider _collider;
    private Transform _transform;
    private GameObject _gameObject;

    public abstract int Amount { get; }

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
        _collider = GetComponent<Collider>();
    }

    public void PickUp() =>
        _gameObject.SetActive(false);

    public void Release() =>
        _gameObject.SetActive(true);
}