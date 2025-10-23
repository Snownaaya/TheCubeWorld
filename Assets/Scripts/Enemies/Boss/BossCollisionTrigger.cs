using Assets.Scripts.HealthCharacters.Characters;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Player;
using System.Threading;
using UnityEngine;
using System;

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
            _cancellationTokenSource = new CancellationTokenSource();
            _bossHealth.Died += OnDeath;
        }

        private void OnDisable()
        {
            _bossHealth.Died -= OnDeath;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
                StartAttackLoop(_cancellationTokenSource.Token).Forget();
                _bossView.StopIdle();
                _bossView.StartAttack();
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

        private async UniTask StartAttackLoop(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                _attacker.Attack();

                await UniTask.Delay(TimeSpan.FromSeconds(_attacker.AttackDelay), cancellationToken: cancellationToken);
            }
        }

        private void OnDeath()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}