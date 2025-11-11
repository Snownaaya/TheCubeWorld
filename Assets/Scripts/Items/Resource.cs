using Assets.Scripts.Datas;
using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;
    [SerializeField] private float _speed;

    public ResourceConfig Config => _config;

    public event Action<Resource> ReturnedToPool;

    public void MovePosition(Vector3 position)
    {
        transform.position = position * _speed;
        transform.rotation = Quaternion.identity;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);

        ReturnedToPool?.Invoke(this);
    }
}