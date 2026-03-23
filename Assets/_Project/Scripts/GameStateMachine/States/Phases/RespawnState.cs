namespace Assets.Scripts.GameStateMachine.States.Phases
{
    using Assets.Project.Scripts.Ground.Filler;
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
        private ICharacterHolder _characterHolder;
        private LevelHazard _levelHazard;

        public RespawnState(
            ISwitcher switcher,
            PauseHandler pauseHandler,
            IInventory inventory,
            IResourceService resourceService,
            ICharacterHolder characterHolder,
            SceneTransitions sceneTransitions,
            LevelHazard level,
            GameEntryPointState gameEntryPointState)
            : base(switcher, inventory, resourceService, sceneTransitions, gameEntryPointState)
        {
            _pauseHandler = pauseHandler;
            _characterHolder = characterHolder;
            _levelHazard = level;   
        }

        public override void Enter()
        {
            base.Enter();

            GameEntryPointState.LossScreen.Close();
            SceneTransitions.GetCurrentLevel();
            _pauseHandler.Remove(GameEntryPointState.LossScreen);
            _characterHolder.Character.CharacterModel.gameObject.SetActive(true);
            _characterHolder.Character.Health.ResetHealth();
            _levelHazard.Reset();
            Switcher.SwitchState<StartLevelState>();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}