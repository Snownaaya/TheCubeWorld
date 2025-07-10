using Assets.Scripts.Interfaces;
using Assets.Scripts.LevelLoader;
using Assets.Scripts.UI.GameUI;
using Assets.Scripts.Other;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private LossScreen _lossScreen;
        [SerializeField] private Character _character;
        [SerializeField] private EndLevel _endLevel;
        [SerializeField] private StartLevel _startLevel;
        [SerializeField] private LevelSelected _levelSelected;

        private GameState _gameState;
        private PauseHandler _pauseHandler;
        private ILevelLoader _levelLoader;

        private void Awake()
        {
            _gameState = new GameState(this);
        }

        [Inject]
        private void Construct(PauseHandler pauseHandler, ILevelLoader levelLoader)
        {
            _pauseHandler = pauseHandler;
            _levelLoader = levelLoader;
        }

        public LossScreen LossScreen => _lossScreen;
        public Character Character => _character;
        public PauseHandler PauseHandler => _pauseHandler;
        public EndLevel EndLevel => _endLevel;
        public StartLevel StartLevel => _startLevel;
        public ILevelLoader LevelLoader => _levelLoader;
        public LevelSelected LevelSelected => _levelSelected;
    }
}