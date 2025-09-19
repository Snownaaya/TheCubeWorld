using Assets.Scripts.Datas;
using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    [Serializable]
    public class BossAttacker : IDamageable
    {
        [SerializeField] private BossConfig _bossConfig;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Transform _attackPoint;

        public float AttackDelay => _bossConfig.Delay;

        public void Attack()
        {
            Collider[] hitEnemy = Physics.OverlapSphere(_attackPoint.position, _bossConfig.AttackRadius, _enemyLayer);

            foreach (Collider enemyCollider in hitEnemy)
            {
                if (enemyCollider.TryGetComponent(out CharacterHealth health))
                    health.TakeDamage(_bossConfig.Damage);
            }
        }
    }
}