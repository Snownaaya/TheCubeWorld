using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Datas;
using System.Threading;
using UnityEngine;
using System;

namespace Assets.Scripts.Player.Attack
{
    public class CharacterAttacker : MonoBehaviour, IDamageable
    {
        [Header("Dependencies")]
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private EnemyCollisionDetector _enemyCollision;
        [SerializeField] private ResourceConsumer _resourceConsumer;

        [SerializeField] private CharacterConfig _characterConfig;

        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            ShootCube(_cancellationTokenSource.Token).Forget();
        }

        private void OnDisable()
        {
            _characterView.StartIdle();
            _characterView.StopAttack();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTask ShootCube(CancellationToken cancellationToken)
        {

            while (cancellationToken.IsCancellationRequested == false)
            {
                Attack();
                await UniTask.Delay(TimeSpan.FromSeconds(_characterConfig.AttackTimer), cancellationToken: cancellationToken);
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
                        health.TakeDamage(_characterConfig.Damage);
                    }
                }
            }
        }
    }
}