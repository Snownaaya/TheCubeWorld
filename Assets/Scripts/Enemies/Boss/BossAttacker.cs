using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    [Serializable]
    public class BossAttacker : IDamageable
    {
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Transform _attackPoint;

        [SerializeField] private float _attackRadius;
        [SerializeField] private float _damage;
        [SerializeField] private float _delay;

        public float AttackRadius => _attackRadius;

        public IEnumerator AttackRoutine()
        {
            var wait = new WaitForSeconds(_delay);

            while (true)
            {
                yield return wait;
                Attack();
            }
        }

        public void Attack()
        {
            Collider[] hitEnemy = Physics.OverlapSphere(_attackPoint.position, _attackRadius, _enemyLayer);

            foreach (Collider enemyCollider in hitEnemy)
            {
                if (enemyCollider.TryGetComponent(out CharacterHealth health))
                    health.TakeDamage(_damage);
            }
        }
    }
}