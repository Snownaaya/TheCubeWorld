using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.Datas;
using Assets.Scripts.Enemies.Boss;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;
    [SerializeField] private float _speed;

    private Transform _targetPosition;
    private ResourceTypes _resourceType;
    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _resourceType = _config.ResourceType;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public ResourceTypes ResourceType => _resourceType;

    public void PickUp() =>
        gameObject.SetActive(false);

    public void Release() =>
        gameObject.SetActive(true);

    public void MovePosition(BossTarget bossTarget)
    {
        Vector3 direction = bossTarget.transform.position + Vector3.up - transform.position;
        _rigidbody.velocity = direction * _speed;
    }

    public void PrepareForCollection()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _collider.isTrigger = true;
    }

    public void PrepareForThrow()
    {
        if (_collider != null)
        {
            _collider.enabled = false;
            _collider.isTrigger = false;
        }
    }
}