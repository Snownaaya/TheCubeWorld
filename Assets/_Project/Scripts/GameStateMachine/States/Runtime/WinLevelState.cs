namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    using Assets.Project.Scripts.Mediators.LevelCompletedMediator;
    using Assets.Scripts.Achievements;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Service.GameMessage;
    using Assets.Scripts.UseCase;

    public class WinLevelState : RuntimeState
    {
        private ICharacterHolder _character;
        private WinLevelHandler _winLevcelHandler;
        private AchievementService _achievementService;
        private WinLevelUseCase _winLevelUseCase;

        public WinLevelState(
            ISwitcher switcher,
            GameEntryPointState gameEntryPointState,
            ICharacterHolder character,
            AchievementService achievementService,
            GameMessageBus gameMessageBus,
            WinLevelHandler winLevcelHandler)
            : base(switcher, gameEntryPointState, character, gameMessageBus)
        {
            _character = character;
            _achievementService = achievementService;
            _winLevcelHandler = winLevcelHandler;

            _winLevelUseCase = new WinLevelUseCase(_achievementService);
        }

        public override void Enter()
        {
            base.Enter();

            _winLevelUseCase.Execute();
            _character.Character.Health.ResetHealth();

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