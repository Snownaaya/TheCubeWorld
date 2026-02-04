using Assets.Scripts.Service.LevelLoaderService;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Datas;
using System.Threading;
using UnityEngine;
using System;

namespace Assets.Scripts.Enemies.Boss
{
    [RequireComponent(typeof(EndLevel), typeof(BossView))]
    public class BossDeathAnimation : MonoBehaviour
    {
        [SerializeField] private BossConfig _bossConfig;

        private CancellationTokenSource _cancellationTokenSource;
        private BossView _bossView;
        private EndLevel _endlevel;

        private void Awake()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _endlevel = GetComponent<EndLevel>();
            _bossView = GetComponent<BossView>();
        }

        private void OnEnable() =>
            _endlevel.LevelEnded += OnLevelEnded;

        private void OnDisable()
        {
            _endlevel.LevelEnded -= OnLevelEnded;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private void OnLevelEnded() =>
            DieDelay(_cancellationTokenSource.Token).Forget();

        private async UniTask DieDelay(CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested)
                return;

            _bossView.StopAttack();
            _bossView.StopIdle();
            _bossView.StartDeath();

            Animator animator = _bossView.GetComponent<Animator>();
            float deathAniamtion = animator.GetCurrentAnimatorStateInfo(0).length;
            float delay = Mathf.Max(deathAniamtion, _bossConfig.AnimationDuration);

            await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken : cancellationToken);
            gameObject.SetActive(false);
        }
    }
}