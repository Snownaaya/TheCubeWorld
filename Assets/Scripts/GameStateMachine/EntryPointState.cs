using Assets.Scripts.Service.LevelLoaderService.Loader;
using Assets.Scripts.GameStateMachine.States.Runtime;
using Assets.Scripts.GameStateMachine.States.Phases;
using Assets.Scripts.Service.LevelLoaderService;
using Assets.Scripts.Service.CharacterService;
using Assets.Scripts.Achievements.Observers;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Player.Wallet;
using Assets.Scripts.Service.Pause;
using Assets.Scripts.Achievements;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Interfaces;
using Assets.Scripts.UI.GameUI;
using Assets.Scripts.PluginYG;
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
        private AchievementService _achievementService;
        private AchievementDeathObserver _achievementDeathObserver;
        private RewardedVideoAds _rewarded;

        private IWallet _wallet;
        private ISwitcher _switcher;
        private IInventory _inventory;
        private ILevelLoader _levelLoader;
        private ICharacterTeleportService _characterTeleportService;

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
            CharacterHolder characterHolder,
            AchievementService achievementService,
            AchievementDeathObserver achievementDeathObserver,
            IWallet wallet,
            RewardedVideoAds rewarded)
        {
            _switcher = switcher;
            _pauseHandler = pauseHandler;
            _characterTeleportService = characterTeleportService;
            _inventory = inventory;
            _levelLoader = levelLoader;
            _characterHolder = characterHolder;
            _achievementService = achievementService;
            _achievementDeathObserver = achievementDeathObserver;
            _wallet = wallet;
            _rewarded = rewarded;
        }

        private void InitializeStates()
        {
            if (_switcher is GameState gameState)
            {
                gameState.Initialize(

                    new StartLevelState(_switcher, this, _characterTeleportService, _characterHolder),
                    new WinLevelState(_switcher, this, _characterHolder, _levelLoader, _achievementService, _wallet),
                    new LossState(_switcher, this, _inventory, _pauseHandler, _achievementDeathObserver, _lossScreen),
                    new RespawnState(_switcher, this, _levelLoader, _pauseHandler, _inventory, _characterHolder, _rewarded)
                );

                _switcher.SwitchState<StartLevelState>();
            }
        }
    }
}