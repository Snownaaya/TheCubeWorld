using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Interfaces;
using Assets.Scripts.UI.GameUI;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public class LossState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private LossScreen _lossScreen;
        private AchievementDeathObserver _achievementDeathObserver;
        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 3f;

        public LossState(ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            PauseHandler pauseHandler,
            AchievementDeathObserver achievementDeathObserver,
            LossScreen lossScreen) : base(switcher, entryPoint, inventory)
        {
            _pauseHandler = pauseHandler;
            _achievementDeathObserver = achievementDeathObserver;
            _lossScreen = lossScreen;
        }

        public override void Enter()
        {
            base.Enter();

            _lossScreen.RewardAdsRequested += OnRespawnState;
            _lossScreen.RespawnRequested += OnRespawnState;
            _cancellationTokenSource = new CancellationTokenSource();
            DelayPause(_cancellationTokenSource.Token).Forget();
        }

        public override void Exit()
        {
            base.Exit();

            _lossScreen.RewardAdsRequested -= OnRespawnState;
            _lossScreen.RespawnRequested -= OnRespawnState;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTask DelayPause(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken : cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            _pauseHandler.SetPause(true);
            EntryPoint.LossScreen.Open();
        }

        private void OnRespawnState() =>
            Switcher.SwitchState<RespawnState>();
    }
}