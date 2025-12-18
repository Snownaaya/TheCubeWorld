using Assets.Scripts.Datas.Character;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class EnemyScaner : MonoBehaviour
    {
        [SerializeField] private Transform _playerModel;
        [SerializeField] private LayerMask _bossMask;

        private CharacterConfig _characterConfig;

        public void Initialize(CharacterConfig characterConfig) =>
            _characterConfig = characterConfig;

        public Collider DetectEnemies()
        {
            Collider[] colliders = Physics.OverlapSphere(_playerModel.position, _characterConfig.DetectionRadius, _bossMask);

            float detectionRadiusSqr = _characterConfig.DetectionRadius * _characterConfig.DetectionRadius;

            for (int i = 0; i < colliders.Length; i++)
            {
                Vector3 toCollider = colliders[i].transform.position - _playerModel.position;
                float distanceSqr = toCollider.sqrMagnitude;

                if (distanceSqr <= detectionRadiusSqr)
                    return colliders[i];
            }

            return null;
        }
    }
}