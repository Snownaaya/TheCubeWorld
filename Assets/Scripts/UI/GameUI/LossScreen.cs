using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Interfaces;
using Assets.Scripts.GameStateMachine.States;
using Reflex.Attributes;
using Assets.Scripts.Service.Pause;

namespace Assets.Scripts.UI.GameUI
{
    public class LossScreen : Screen, IPause
    {
        [SerializeField] private Button _respawn;
        [SerializeField] private Button _exitMenu;

        private bool _isPause;

        public event Action RewardAdsRequested;
        public event Action RespawnRequested;
        public event Action ExitMenuRequested;

        private ISwitcher _switcher;
        private PauseHandler _pauseHandler;

        [Inject]
        private void Construct(ISwitcher switcher, PauseHandler pauseHandler)
        {
            _switcher = switcher;
            _pauseHandler = pauseHandler;
            pauseHandler.Add(this);
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnClickReward);
            _respawn.onClick.AddListener(OnClickRespawn);
            _exitMenu.onClick.AddListener(OnClickExitMenu);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnClickReward);
            _respawn.onClick.RemoveListener(OnClickRespawn);
            _exitMenu.onClick.RemoveListener(OnClickExitMenu);
        }

        public override void Open()
        {
            _isPause = true;
            CanvasGroup.alpha = 1;
            RectTransform.gameObject.SetActive(true);
            CanvasGroup.blocksRaycasts = true;
        }

        public override void Close()
        {
            _isPause = false;
            CanvasGroup.alpha = 0;
            RectTransform.gameObject.SetActive(false);
            CanvasGroup.blocksRaycasts = false;
            SetPause(false);
        }

        public void SetPause(bool isPaused)
        {
            _isPause = isPaused;

            Time.timeScale = isPaused ? 0 : 1;
        }

        private void OnClickExitMenu() =>
            RewardAdsRequested?.Invoke();

        private void OnClickRespawn()
        {
            RespawnRequested?.Invoke();
            _switcher.SwitchState<RespawnState>();
        }

        private void OnClickReward() =>
            ExitMenuRequested?.Invoke();
    }
}