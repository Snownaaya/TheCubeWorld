namespace Assets.Scripts.GameStateMachine.States.Runtime
{
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Scripts.Input;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Service.CharacterService;
    using Assets.Scripts.Service.GameMessage;

    public class StartLevelState : RuntimeState
    {
        private ICharacterTeleportService _characterTeleportService;
        private LevelHazard _levelHazard;
        private GameEntryPointState _gameEntryPointState;
        private IJoystickInput _joystickInput;

        public StartLevelState(
            ISwitcher switcher,
            GameEntryPointState gameEntryPointState,
            ICharacterTeleportService characterTeleportService,
            ICharacterHolder characterHolder,
            GameMessageBus gameMessageBus,
            LevelHazard levelHazard,
            IJoystickInput joystickInput)
            : base(switcher, gameEntryPointState, characterHolder, gameMessageBus)
        {
            _characterTeleportService = characterTeleportService;
            _gameEntryPointState = gameEntryPointState;
            _levelHazard = levelHazard;
            _joystickInput = joystickInput;
        }

        public override void Enter()
        {
            base.Enter();

            _joystickInput.Show();

            _gameEntryPointState.EndLevel.LevelEnded += OnStartLevel;
            _characterTeleportService?.SpawnAtStart();
            _levelHazard.StartScale();
        }

        public override void Exit()
        {
            base.Exit();

            _levelHazard.Stop();
            _gameEntryPointState.EndLevel.LevelEnded -= OnStartLevel;
        }

        private void OnStartLevel() =>
            Switcher.SwitchState<WinLevelState>();
    }
}