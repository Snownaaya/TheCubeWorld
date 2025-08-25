using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;
using System;
using Assets.Scripts.Datas;

namespace Assets.Scripts.Enemies.Boss
{
    [Serializable]
    public class BossAttacker : IDamageable
    {
        [SerializeField] private BossConfig _bossConfig;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Transform _attackPoint;

        public IEnumerator AttackRoutine()
        {
            var wait = new WaitForSeconds(_bossConfig.Delay);

            while (true)
            {
                yield return wait;
                Attack();
            }
        }

        public void Attack()
        {
            Collider[] hitEnemy = Physics.OverlapSphere(_attackPoint.position, _bossConfig.AttackRadius, _enemyLayer);

            foreach (Collider enemyCollider in hitEnemy)
            {
               BinaryFormatter formatter = new BinaryFormatter();

                if (enemyCollider.TryGetComponent(out CharacterHealth health))
                    health.TakeDamage(_bossConfig.Damage);
            }
        }
    }
}