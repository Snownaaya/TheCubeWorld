using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
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

        public LossState(ISwitcher switcher, EntryPointState entryPoint) : base(switcher, entryPoint) { }

        public override void Enter()
        {
            base.Enter();
            _cancellationTokenSource = new CancellationTokenSource();

            DelayPause(_cancellationTokenSource.Token).Forget();
            EntryPoint.Inventory.Reset();
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
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            EntryPoint.PauseHandler.SetPause(true);
            EntryPoint.LossScreen.Open();
        }
    }
}