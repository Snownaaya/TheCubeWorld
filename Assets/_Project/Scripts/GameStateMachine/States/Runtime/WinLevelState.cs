namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    using Assets.Project.Scripts.Mediators.LevelCompletedMediator;
    using Assets.Scripts.Achievements;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Service.GameMessage;
    using Assets.Scripts.UseCase;

    public class WinLevelState : RuntimeState
    {
        private ICharacterHolder _character;
        private IResourceService _resourceService;
        private WinLevelHandler _winLevcelHandler;
        private AchievementService _achievementService;
        private WinLevelUseCase _winLevelUseCase;

        public WinLevelState(
            ISwitcher switcher,
            ICharacterHolder character,
            IResourceService resourceService,
            GameMessageBus gameMessageBus,
            GameEntryPointState gameEntryPointState,
            AchievementService achievementService,
            WinLevelHandler winLevcelHandler)
            : base(switcher, gameEntryPointState, character, gameMessageBus, resourceService)
        {
            _character = character;
            _achievementService = achievementService;
            _winLevcelHandler = winLevcelHandler;
            _resourceService = resourceService;

            _winLevelUseCase = new WinLevelUseCase(_achievementService);
        }

        public override void Enter()
        {
            base.Enter();

            _winLevelUseCase.Execute();
            _character.Character.Health.ResetHealth();

            _resourceService.Clear();
            _winLevcelHandler.ProcessDefaultCoimResult();
            _winLevcelHandler.ProcessRewardWheelResult();
            _winLevcelHandler.Show();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}