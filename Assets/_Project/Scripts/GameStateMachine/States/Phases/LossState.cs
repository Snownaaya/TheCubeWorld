using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.UI.GameUI;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Assets.Scripts.GameStateMachine.States.Phases
{
    public class LossState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private LossScreen _lossScreen;
        private CancellationTokenSource _cancellationTokenSource; 
        private ILevelLoader _levelLoader;

        private float _delay = 2f;

        public LossState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            IInventory inventory,
            IResourceService resourceService,
            PauseHandler pauseHandler,
            LossScreen lossScreen,
            ILevelLoader levelLoader) : base(switcher,
                entryPoint, 
                inventory,
                resourceService)
        {
            _pauseHandler = pauseHandler;
            _lossScreen = lossScreen;
            _levelLoader = levelLoader;
        }

        public override void Enter()
        {
            base.Enter();

            _cancellationTokenSource = new CancellationTokenSource();

            _lossScreen.RewardAdsRequested += OnRespawnAdsState;
            _lossScreen.RespawnRequested += OnRespawnState;
            _lossScreen.ExitMenuRequested += OnExitMenu;

            DelayPause(_cancellationTokenSource.Token).Forget();
        }

        public override void Exit()
        {
            base.Exit();

            _lossScreen.RewardAdsRequested -= OnRespawnAdsState;
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
            _lossScreen.Open();
        }

        private void OnRespawnAdsState()
        {
            Switcher.SwitchState<RespawnState>();
            ResourceService.Clear();
        }

        private void OnRespawnState()
        {
            Switcher.SwitchState<RespawnState>();
            Inventory.Reset();
            ResourceService.Clear();
        }

        private void OnExitMenu()
        {
            ResourceService.Clear();
            _levelLoader.Load(EntryPoint.LevelSelected.GetMainMenu());
        }
    }
}