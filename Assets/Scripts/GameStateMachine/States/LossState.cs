using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

namespace Assets.Scripts.GameStateMachine.States
{
    public class LossState : BaseGameState
    {
        private CancellationTokenSource _cancellationTokenSource;
        private IInventory _inventory;
        private PauseHandler _pauseHandler;

        private float _delay = 2f;

        public LossState(ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            PauseHandler pauseHandler) : base(switcher, entryPoint)
        {
            _inventory = inventory;
            _pauseHandler = pauseHandler;
        }

        public override void Enter()
        {
            base.Enter();
            _cancellationTokenSource = new CancellationTokenSource();

            DelayPause(_cancellationTokenSource.Token).Forget();
            _inventory.Reset();
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

            _pauseHandler.SetPause(true);
            EntryPoint.LossScreen.Open();
        }
    }
}