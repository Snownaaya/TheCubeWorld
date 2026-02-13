using Assets.Scripts.Achievements;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.GameMessage;
using Assets.Scripts.UseCase;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public class WinLevelState : RuntimeState
    {
        private ICharacterHolder _character;
        private AchievementService _achievementService;
        private WinLevelUseCase _winLevelUseCase;

        public WinLevelState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            ICharacterHolder character,
            AchievementService achievementService,
            GameMessageBus gameMessageBus)
            : base(switcher, entryPoint, character, gameMessageBus)
        {
            _character = character;
            _achievementService = achievementService;
            _winLevelUseCase = new WinLevelUseCase(_achievementService);
        }

        public override void Enter()
        {
            base.Enter();

            _winLevelUseCase.Execute();
            _character.Character.Health.ResetHealth();

            EntryPoint.WinLevelWindowMediator.ProcessDefaultCoimResult();
            EntryPoint.WinLevelWindowMediator.ProcessRewardWheelResult();
            EntryPoint.WinLevelWindowMediator.Show();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}