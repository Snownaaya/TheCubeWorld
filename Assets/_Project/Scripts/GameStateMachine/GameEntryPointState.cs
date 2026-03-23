namespace Assets.Scripts.GameStateMachine
{
    using Assets.Project.Scripts.Ground.Filler;
    using Assets.Project.Scripts.Mediators.LevelCompletedMediator;
    using Assets.Scripts.Achievements;
    using Assets.Scripts.GameStateMachine.States.Phases;
    using Assets.Scripts.GameStateMachine.States.Runtime;
    using Assets.Scripts.Input;
    using Assets.Scripts.Interfaces;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.Player.Inventory;
    using Assets.Scripts.Service.CharacterService;
    using Assets.Scripts.Service.GameMessage;
    using Assets.Scripts.Service.LevelLoaderService;
    using Assets.Scripts.Service.Pause;
    using Assets.Scripts.UI.Loss;
    using Assets.Scripts.UseCase;
    using Reflex.Attributes;
    using UnityEngine;

    public class GameEntryPointState : MonoBehaviour
    {
        [SerializeField] private LossScreen _lossScreen;
        [SerializeField] private EndLevel _endLevel;

        private PauseHandler _pauseHandler;
        private ICharacterHolder _characterHolder;
        private AchievementService _achievementService;

        private ISwitcher _switcher;
        private IInventory _inventory;
        private ICharacterTeleportService _characterTeleportService;
        private IResourceService _resourceService;
        private IJoystickInput _joystickInput;
        private GameMessageBus _gameMessageBus;
        private SceneTransitions _sceneTransitions;
        private LevelHazard _levelHazard;
        private WinLevelHandler _levelHandler;

        public LossScreen LossScreen => _lossScreen;

        public EndLevel EndLevel => _endLevel;

        private void Awake() =>
            InitializeStates();

        [Inject]
        private void Construct(
            ISwitcher switcher,
            PauseHandler pauseHandler,
            ICharacterTeleportService characterTeleportService,
            IInventory inventory,
            ICharacterHolder characterHolder,
            AchievementService achievementService,
            IResourceService resourceService,
            GameMessageBus gameMessageBus,
            SceneTransitions sceneTransitions,
            LevelHazard level,
            IJoystickInput joystickInput,
            WinLevelHandler winLevelHandler)
        {
            _switcher = switcher;
            _pauseHandler = pauseHandler;
            _characterTeleportService = characterTeleportService;
            _inventory = inventory;
            _characterHolder = characterHolder;
            _achievementService = achievementService;
            _resourceService = resourceService;
            _gameMessageBus = gameMessageBus;
            _sceneTransitions = sceneTransitions;
            _levelHazard = level;
            _joystickInput = joystickInput;
            _levelHandler = winLevelHandler;
        }

        private void InitializeStates()
        {
            if (_switcher is GameState gameState)
            {
                gameState.Initialize(
                    new StartLevelState(_switcher, this, _characterTeleportService, _characterHolder, _gameMessageBus, _levelHazard, _joystickInput),
                    new WinLevelState(_switcher, this, _characterHolder, _achievementService, _gameMessageBus, _levelHandler),
                    new LossState(_switcher, _inventory, _resourceService, _pauseHandler, _sceneTransitions, this),
                    new RespawnState(_switcher, _pauseHandler, _inventory, _resourceService, _characterHolder, _sceneTransitions, _levelHazard, this)
                );

                _switcher.SwitchState<StartLevelState>();
            }
        }
    }
}