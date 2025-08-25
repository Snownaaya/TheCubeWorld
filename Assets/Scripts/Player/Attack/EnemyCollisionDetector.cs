using UnityEngine;
using System;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Player.Attack
{
    [Serializable]
    public class EnemyCollisionDetector
    {
        [SerializeField] private LayerMask _enemyLayerMask;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private Transform _playerModel;

        public Collider[] DetectEnemies() =>
            Physics.OverlapSphere(_playerModel.position, _characterConfig.DetectionRadius, _enemyLayerMask);
    }
}