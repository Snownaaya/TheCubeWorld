using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Attack
{
    public class CharacterAttacker : MonoBehaviour, IDamageable
    {
        [Header("Dependencies")]
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private EnemyCollisionDetector _enemyCollision;
        [SerializeField] private ResourceConsumer _resourceConsumer;

        [Header("Settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private float _attackTimer = 1;

        private void Start() =>
            StartCoroutine(ShootCube());

        private IEnumerator ShootCube()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(_attackTimer);
                Attack();
            }
        }

        public void Attack()
        {
            Collider[] hitEnemy = _enemyCollision.DetectEnemies();

            foreach (Collider enemyCollider in hitEnemy)
            {
                if (enemyCollider.TryGetComponent(out BossHealth health))
                {
                    if (_resourceConsumer.TryConsumeResource())
                    {
                        _characterView.StartAttackState();
                        _characterView.StopMovement();
                        _characterView.StopIdle();
                        _characterView.StopWalk();
                        _characterView.StartAttack();
                        health.TakeDamage(_damage);
                    }
                    //_resourceConsumer.ResourceSpawner.Push();
                }
            }
        }

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_enemyCollision.PlayerModel.position, _enemyCollision.DetectionRadius);
        }
#endif
    }
}