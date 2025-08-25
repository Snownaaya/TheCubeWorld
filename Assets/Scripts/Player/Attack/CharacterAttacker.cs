using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using Assets.Scripts.Datas;

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

        private void Awake() =>
            _cancellationTokenSource = new CancellationTokenSource();

        private void Start() =>
            ShootCube(_cancellationTokenSource.Token).Forget();

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
                    //_resourceConsumer.ResourceSpawner.Push();
                }
            }
        }
    }
}