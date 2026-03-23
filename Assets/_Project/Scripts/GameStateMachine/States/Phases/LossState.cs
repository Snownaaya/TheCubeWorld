namespace Assets.Scripts.GameStateMachine.States.Phases
{
    using System;
    using System.Threading;
    using Assets.Project.Scripts.GameStateMachine.States.MainMenu;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.Service.Pause;
    using Assets.Scripts.UseCase;
    using Cysharp.Threading.Tasks;

    public class LossState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private CancellationTokenSource _cancellationTokenSource;

        private float _delay = 2f;

        public LossState(
            ISwitcher switcher,
            IInventory inventory,
            IResourceService resourceService,
            PauseHandler pauseHandler,
            SceneTransitions sceneTransitions,
            GameEntryPointState gameEntryPointState)
            : base(switcher, inventory, resourceService, sceneTransitions, gameEntryPointState)
        {
            _pauseHandler = pauseHandler;
        }

        public override void Enter()
        {
            base.Enter();

            _cancellationTokenSource = new CancellationTokenSource();

            GameEntryPointState.LossScreen.RewardAdsRequested += OnRespawnAdsState;
            GameEntryPointState.LossScreen.RespawnRequested += OnRespawnState;
            GameEntryPointState.LossScreen.ExitMenuRequested += OnExitMenu;

            DelayPause(_cancellationTokenSource.Token).Forget();
        }

        public override void Exit()
        { base.Exit();

            GameEntryPointState.LossScreen.RewardAdsRequested -= OnRespawnAdsState;
            GameEntryPointState.LossScreen.RespawnRequested -= OnRespawnState;
            GameEntryPointState.LossScreen.ExitMenuRequested -= OnExitMenu;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTask DelayPause(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay),
                cancellationToken: cancellationToken);

            if (cancellationToken.IsCancellationRequested)
                return;

            _pauseHandler.SetPause(true);
            GameEntryPointState.LossScreen.Open();
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
            Switcher.SwitchState<MainMenuState>();
            ResourceService.Clear();
        }
    }
}