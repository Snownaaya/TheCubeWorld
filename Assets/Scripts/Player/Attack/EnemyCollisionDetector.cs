using UnityEngine;
using System;

namespace Assets.Scripts.Player.Attack
{
    [Serializable]
    public class EnemyCollisionDetector
    {
        [SerializeField] private LayerMask _enemyLayerMask;
        [SerializeField] private float _detectionRadius;
        [SerializeField] private Transform _playerModel;

        public float DetectionRadius => _detectionRadius;
        public Transform PlayerModel => _playerModel;

        public Collider[] DetectEnemies() =>
            Physics.OverlapSphere(_playerModel.position, _detectionRadius, _enemyLayerMask);
    }
}