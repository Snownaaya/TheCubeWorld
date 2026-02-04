using Assets.Scripts.Datas;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;
    [SerializeField] private float _speed;

    public Transform SpawnPoint { get; private set; }
    public ResourceConfig Config => _config;

    public void MovePosition(Vector3 position)
    {
        transform.position = position * _speed;
        transform.rotation = Quaternion.identity;
    }

    public void SetSpawnPoint(Transform spawnPoint) =>
        SpawnPoint = spawnPoint;
}