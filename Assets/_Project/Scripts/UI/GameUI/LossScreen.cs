using Assets.Scripts.Service.Pause;
using Reflex.Attributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameUI
{
    public class LossScreen : Screen, IPause
    {
        [SerializeField] private Button _respawn;
        [SerializeField] private Button _exitMenu;

        private bool _isPause;
        private float _time;

        public event Action RewardAdsRequested;
        public event Action RespawnRequested;
        public event Action ExitMenuRequested;

        [Inject]
        private void Construct(PauseHandler pauseHandler) =>
            pauseHandler.Add(this);

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
            if (CanvasGroup == null || RectTransform == null)
                return;

            CanvasGroup.alpha = 1;
            RectTransform.gameObject.SetActive(true);
            CanvasGroup.blocksRaycasts = true;
            SetPause(true);
        }

        public override void Close()
        {
            CanvasGroup.alpha = 0;
            RectTransform.gameObject.SetActive(false);
            CanvasGroup.blocksRaycasts = false;
            SetPause(false);

        }

        public void SetPause(bool isPaused) =>
            Time.timeScale = isPaused ? 0 : 1;

        private void OnClickExitMenu() =>
            ExitMenuRequested?.Invoke();

        private void OnClickRespawn() =>
            RespawnRequested?.Invoke();

        private void OnClickReward() =>
            RewardAdsRequested?.Invoke();
    }
}