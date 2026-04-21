namespace Assets.Scripts.GameStateMachine.States.Phases
{
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Scripts.Camera;
    using Assets.Scripts.GameStateMachine.States.Runtime;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.Service.Pause;
    using Assets.Scripts.UseCase;

    public class RespawnState : PhasesState
    {
        private PauseHandler _pauseHandler;
        private LevelHazard _levelHazard;
        private ICharacterHolder _characterHolder;
        private IVirtualCamera _virtualCamera;

        public RespawnState(
            ISwitcher switcher,
            PauseHandler pauseHandler,
            IInventory inventory,
            IResourceService resourceService,
            ICharacterHolder characterHolder,
            SceneTransitions sceneTransitions,
            LevelHazard level,
            GameEntryPointState gameEntryPointState,
            IVirtualCamera virtualCamera)
            : base(switcher, inventory, resourceService, sceneTransitions, gameEntryPointState)
        {
            _pauseHandler = pauseHandler;
            _characterHolder = characterHolder;
            _levelHazard = level;
            _virtualCamera = virtualCamera;
        }

        public override void Enter()
        {
            base.Enter();

            GameEntryPointState.LossScreen.Close();
            SceneTransitions.GetCurrentLevel();
            _pauseHandler.Remove(GameEntryPointState.LossScreen);
            _levelHazard.Reset();

            _virtualCamera.ResetTransform();
            _characterHolder.Character.Health.ResetHealth();
            _characterHolder.Character.CharacterModel.gameObject.SetActive(true);
            _virtualCamera.SetTarget(_characterHolder.Character.CharacterModel);
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}