using Assets.Scripts.Achievements;
using Assets.Scripts.GameStateMachine.States.Phases;
using Assets.Scripts.GameStateMachine.States.Runtime;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Mediators.LevelCompletedMediator;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.GameMessage;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.UI.GameUI;
using Assets.Scripts.UseCase;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine
{
    public class EntryPointState : MonoBehaviour
    {
        [SerializeField] private LossScreen _lossScreen;
        [SerializeField] private EndLevel _endLevel;
        [SerializeField] private WinLevelWindowMediator _winLevelWindowMediator;

        private PauseHandler _pauseHandler;
        private ICharacterHolder _characterHolder;
        private AchievementService _achievementService;

        private ISwitcher _switcher;
        private IInventory _inventory;
        private ICharacterTeleportService _characterTeleportService;
        private IResourceService _resourceService;
        private GameMessageBus _gameMessageBus;
        private SceneTransitions _sceneTransitions;

        public LossScreen LossScreen => _lossScreen;
        public EndLevel EndLevel => _endLevel;
        public WinLevelWindowMediator WinLevelWindowMediator => _winLevelWindowMediator;

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
            SceneTransitions sceneTransitions)
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
        }

        private void InitializeStates()                 
        {
            if (_switcher is GameState gameState)
            {
                gameState.Initialize(

                    new StartLevelState(_switcher, this, _characterTeleportService, _characterHolder, _gameMessageBus),
                    new WinLevelState(_switcher, this, _characterHolder, _achievementService, _gameMessageBus),
                    new LossState(_switcher, this, _inventory, _resourceService, _pauseHandler, _lossScreen, _sceneTransitions),
                    new RespawnState(_switcher, this, _pauseHandler, _inventory, _resourceService, _characterHolder, _sceneTransitions)
                );

                _switcher.SwitchState<StartLevelState>();
            }
        }
    }
}