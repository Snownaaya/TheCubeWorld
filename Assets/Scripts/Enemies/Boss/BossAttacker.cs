using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;
using System;

namespace Assets.Scripts.Enemies.Boss
{
    [Serializable]
    public class BossAttacker : IDamageable
    {
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Transform _attackPoint;

        [SerializeField] private float _attackRadius;
        [SerializeField] private float _delay;
        [SerializeField] private int _damage;

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
               BinaryFormatter formatter = new BinaryFormatter();
                if (enemyCollider.TryGetComponent(out CharacterHealth health))
                    health.TakeDamage(_damage);
            }
        }
    }
}