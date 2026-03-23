namespace Assets.Project.Scripts.GameStateMachine
{
    using Assets.Project.Scripts.GameStateMachine.States.MainMenu;
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Scripts.GameStateMachine;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Service.Audio;
    using Assets.Scripts.UI.MainMenu;
    using Assets.Scripts.UseCase;
    using Reflex.Attributes;
    using UnityEngine;

    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private StartButton _startButton;

        private MainMenuState _menuState;

        private ISwitcher _switcher;
        private LevelHazard _levelHazard;
        private ForegroundAudioService _audioService;
        private SceneTransitions _sceneTransitions;

        private void Awake() =>
            Initailize();

        [Inject]
        private void Construct(
            ISwitcher switcher,
            LevelHazard levelHazard,
            ForegroundAudioService foregroundAudioService,
            SceneTransitions sceneTransitions)
        {
            _audioService = foregroundAudioService;
            _sceneTransitions = sceneTransitions;   
            _switcher = switcher;
            _levelHazard = levelHazard;
        }

        private void Initailize()
        {
            if (_switcher is GameState gameState)
                gameState.Initialize(_menuState = new MainMenuState(_switcher, _startButton, _levelHazard, _audioService, _sceneTransitions));

            _switcher.SwitchState<MainMenuState>();
        }
    }
}