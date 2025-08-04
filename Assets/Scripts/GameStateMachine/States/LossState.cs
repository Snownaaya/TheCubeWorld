using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    public class LossState : BaseGameState
    {
        private CancellationTokenSource _cancellationTokenSource;
        private float _delay = 2f;

        public LossState(ISwitcher switcher, EntryPoint flow) : base(switcher, flow) { }

        public override void Enter()
        {
            base.Enter();
            _cancellationTokenSource = new CancellationTokenSource();

            DelayPause(_cancellationTokenSource.Token).Forget();
        }

        public override void Exit()
        {
            base.Exit();

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTask DelayPause(CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    return;

                GameFlow.PauseHandler.SetPause(true);
                GameFlow.LossScreen.Open();
            }
            catch(OperationCanceledException)
            {
                Debug.Log("LossState DelayPause was cancelled");
            }
        }
    }
}