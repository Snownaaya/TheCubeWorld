using Assets.Project.Scripts.Ground.Filler;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.GameMessage;

namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    public class StartLevelState : RuntimeState
    {
        private ICharacterTeleportService _characterTeleportService;
        private LevelHazard _levelHazard;

        public StartLevelState(
            ISwitcher switcher,
            EntryPointState entryPoint,
            ICharacterTeleportService characterTeleportService,
            ICharacterHolder characterHolder,
            GameMessageBus gameMessageBus,
            LevelHazard levelHazard)
            : base(switcher, entryPoint, characterHolder, gameMessageBus)
        {
            _characterTeleportService = characterTeleportService;
            _levelHazard = levelHazard; 
        }

        public override void Enter()
        {
            base.Enter();

            EntryPoint.EndLevel.LevelEnded += OnStartLevel;
            _characterTeleportService?.SpawnAtStart();
            _levelHazard.StartLevel();
        }

        public override void Exit()
        {
            base.Exit();

            EntryPoint.EndLevel.LevelEnded -= OnStartLevel;
        }

        private void OnStartLevel() =>
            Switcher.SwitchState<WinLevelState>();
    }
}