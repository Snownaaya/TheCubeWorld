using Assets.Scripts.GameStateMachine.States;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.UI.GameUI;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine
{
    public class EntryPointState : MonoBehaviour
    {
        [SerializeField] private LossScreen _lossScreen;
        [SerializeField] private EndLevel _endLevel;
        [SerializeField] private LevelSelected _levelSelected;

        private PauseHandler _pauseHandler;
        private CharacterHolder _characterHolder;
        private ISwitcher _switcher;
        private ICharacterTeleportService _characterTeleportService;
        private IInventory _inventory;
        private ILevelLoader _levelLoader;

        public LossScreen LossScreen => _lossScreen;
        public EndLevel EndLevel => _endLevel;
        public LevelSelected LevelSelected => _levelSelected;

        private void Awake() =>
            InitializeStates();
       
        [Inject]
        private void Construct(ISwitcher switcher,
            PauseHandler pauseHandler,
            ICharacterTeleportService characterTeleportService,
            IInventory inventory,
            ILevelLoader levelLoader,
            CharacterHolder characterHolder
            )
        {
            _switcher = switcher;
            _pauseHandler = pauseHandler;
            _characterTeleportService = characterTeleportService;
            _inventory = inventory;
            _levelLoader = levelLoader;
            _characterHolder = characterHolder;
        }

        private void InitializeStates()
        {
            if (_switcher is GameState gameState)
            {
                gameState.Initialize(

                    new StartLevelState(_switcher, this, _characterTeleportService, _characterHolder),
                    new EndLevelState(_switcher, this, _levelLoader),
                    new LossState(_switcher, this, _inventory, _pauseHandler),
                    new RespawnState(_switcher, this, _levelLoader, _pauseHandler, _inventory)
                );

                _switcher.SwitchState<StartLevelState>();
            }
        }
    }
}