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

        private GameState _gameState;
        private PauseHandler _pauseHandler;
        private ILevelLoader _levelLoader;
        private IInventory _inventory;
        private ICharacterTeleportService _characterSpawnService;

        private void Awake()
        {
            _gameState = new GameState(this);
        }

        [Inject]
        private void Construct(ICharacterTeleportService characterSpawnService, PauseHandler pauseHandler, ILevelLoader levelLoader, IInventory inventory)
        {
            _characterSpawnService = characterSpawnService;
            _pauseHandler = pauseHandler;
            _levelLoader = levelLoader;
            _inventory = inventory;
        }

        public LossScreen LossScreen => _lossScreen;
        public PauseHandler PauseHandler => _pauseHandler;
        public EndLevel EndLevel => _endLevel;
        public ILevelLoader LevelLoader => _levelLoader;
        public IInventory Inventory => _inventory;
        public LevelSelected LevelSelected => _levelSelected;
        public ICharacterTeleportService CharacterSpawnService => _characterSpawnService;
    }
}