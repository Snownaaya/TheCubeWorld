using Assets.Scripts.Player;
using Assets.Scripts.UI.HealthCharacters.Characters;
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
            _cancellationTokenSource = new CancellationTokenSource();
            StartAttackLoop(_cancellationTokenSource.Token).Forget();
            _bossHealth.Died += OnDeath;
        }

        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _bossHealth.Died -= OnDeath;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {
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
                await UniTask.Delay(TimeSpan.FromSeconds(_attacker.AttackDelay), cancellationToken: cancellationToken);
                _attacker.Attack();
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