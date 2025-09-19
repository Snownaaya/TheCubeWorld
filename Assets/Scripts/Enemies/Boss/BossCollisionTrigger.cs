using Assets.Scripts.HealthCharacters.Characters;
using Assets.Scripts.Player;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Enemies.Boss
{
    [RequireComponent(typeof(BossView), typeof(BossHealth))]
    public class BossCollisionTrigger : MonoBehaviour
    {
        [SerializeField] private BossAttacker _attacker;

        private BossHealth _bossHealth;
        private BossView _bossView;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _bossHealth = GetComponent<BossHealth>();
            _bossView = GetComponent<BossView>();
            _bossView.Init();
        }

        private void OnEnable()
        {
            _bossHealth.Died += OnDeath;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            _bossHealth.Died -= OnDeath;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _bossView.StopIdle();
                _bossView.StartAttack();
                StartAttackLoop();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                _bossView.StartIdle();
                _bossView.StopAttack();
            }
        }

        private void OnDeath()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private void StartAttackLoop()
        {
            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
                return;

            AttackRoutine(_cancellationTokenSource.Token).Forget();
        }

        private async UniTask AttackRoutine(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_attacker.AttackDelay), cancellationToken: cancellationToken);

            while (cancellationToken.IsCancellationRequested == false)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_attacker.AttackDelay), cancellationToken: cancellationToken);
                _attacker.Attack();
            }
        }
    }
}