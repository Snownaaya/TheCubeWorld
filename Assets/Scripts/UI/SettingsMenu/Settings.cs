using Assets.Scripts.Service.Pause;
using Screen = Assets.Scripts.UI.GameUI.Screen;
using System;
using Reflex.Attributes;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.UI.SettingsMenu
{
    public class Settings : Screen, IPause
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitMainMenu;

        public event Action MainMenuRequested;

        [Inject]
        private void Construct(PauseHandler pauseHandler) =>
            pauseHandler.Add(this);

        private void OnEnable()
        {
            Button.onClick.AddListener(Open);
            _settingsButton.onClick.AddListener(Close);
            _exitMainMenu.onClick.AddListener(OnExitMenu);
        }

        private void OnDisable()
        {
            Button.onClick?.RemoveListener(Open);
            _settingsButton.onClick.RemoveListener(Close);
            _exitMainMenu.onClick.RemoveListener(OnExitMenu);
        }

        public override void Open()
        {
            RectTransform.gameObject.SetActive(true);
            CanvasGroup.alpha = 1;
            SetPause(true);
        }

        public override void Close()
        {
            RectTransform.gameObject.SetActive(false);
            CanvasGroup.alpha = 0;
            SetPause(false);
        }

        public void SetPause(bool isPaused) =>
            Time.timeScale = isPaused ? 0 : 1;

        private void OnExitMenu() =>
            MainMenuRequested?.Invoke();
    }
}