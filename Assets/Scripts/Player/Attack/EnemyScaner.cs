using Assets.Scripts.Datas;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class EnemyScaner : MonoBehaviour
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private Transform _playerModel;

        public Collider DetectEnemies()
        {
            Collider[] colliders = new Collider[250];

            int hitCount = Physics.OverlapSphereNonAlloc(
                _playerModel.position,
                _characterConfig.DetectionRadius,
                colliders);

            for (int i = 0; i < hitCount; i++)
            {
                float distance = Vector3.Distance(_playerModel.position, colliders[i].transform.position);

                if (distance <= _characterConfig.DetectionRadius)
                    return colliders[i];
            }

            return null;
        }
    }
}