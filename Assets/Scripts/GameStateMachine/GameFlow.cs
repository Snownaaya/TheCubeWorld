using Assets.Scripts.LevelLoader;
using Assets.Scripts.Other;
using Assets.Scripts.UI.GameUI;
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

        private GameState _gameState;
        private PauseHandler _pauseHandler;

        private void Awake()
        {
            _gameState = new GameState(this);
        }

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            _pauseHandler = pauseHandler;
        }
        
        public LossScreen LossScreen => _lossScreen;
        public Character Character => _character;
        public PauseHandler PauseHandler => _pauseHandler;
        public EndLevel EndLevel => _endLevel;
        public StartLevel StartLevel => _startLevel;
    }
}