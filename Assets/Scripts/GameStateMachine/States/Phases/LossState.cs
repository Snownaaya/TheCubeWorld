using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Items;
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
        private ILevelLoader _levelLoader;
        private PauseHandler _pauseHandler;
        private LossScreen _lossScreen;
        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 3f;

        public LossState(ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            IResourceService resourceService,
            PauseHandler pauseHandler,
            LossScreen lossScreen,
            ILevelLoader levelLoader) : base(switcher, entryPoint, inventory, resourceService)
        {
            _pauseHandler = pauseHandler;
            _lossScreen = lossScreen;
            _levelLoader = levelLoader;
        }

        public override void Enter()
        {
            base.Enter();

            _lossScreen.RewardAdsRequested += OnRespawnState;
            _lossScreen.RespawnRequested += OnRespawnState;
            _lossScreen.ExitMenuRequested += OnExitMenu;
            _cancellationTokenSource = new CancellationTokenSource();
            DelayPause(_cancellationTokenSource.Token).Forget();
        }

        public override void Exit()
        {
            base.Exit();

            _lossScreen.RewardAdsRequested -= OnRespawnState;
            _lossScreen.RespawnRequested -= OnRespawnState;
            _lossScreen.ExitMenuRequested -= OnExitMenu;
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

        private void OnExitMenu() =>
            _levelLoader.Load(EntryPoint.LevelSelected.GetMainMenu());
    }
}