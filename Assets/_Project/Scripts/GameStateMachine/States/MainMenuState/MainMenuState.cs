namespace Assets.Project.Scripts.GameStateMachine.States.MainMenu
{
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Project.Scripts.UseCase;
    using Assets.Scripts.GameStateMachine.States;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Service.Audio;
    using Assets.Scripts.UI.MainMenu;
    using Assets.Scripts.UseCase;

    public class MainMenuState : BaseGameState
    {
        private LevelHazard _levelHazard;
        private StartButton _startButton;
        private StartButtonUseCase _startButtonUseCase;
        private ForegroundAudioService _audioService;
        private SceneTransitions _sceneTransitions;

        public MainMenuState(
            ISwitcher switcher,
            StartButton startButton,
            LevelHazard levelHazard,
            ForegroundAudioService foregroundAudioService,
            SceneTransitions sceneTransitions)
            : base(switcher)
        {
            _audioService = foregroundAudioService;
            _sceneTransitions = sceneTransitions;
            _startButton = startButton;
            _levelHazard = levelHazard;

            _startButtonUseCase = new StartButtonUseCase(_audioService, _sceneTransitions);
        }

        public override void Enter()
        {
            base.Enter();

            _startButton.ClickButton += OnStartButton;

            _levelHazard.StartScale();
        }

        public override void Exit()
        {
            base.Exit();
            _startButton.ClickButton -= OnStartButton;
        }

        private void OnStartButton() =>
            _startButtonUseCase.Execute();
    }
}