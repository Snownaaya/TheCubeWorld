namespace Assets.Scripts.UI.SettingsMenu
{
    using System;
    using Assets.Scripts.Service.Audio;
    using Assets.Scripts.Service.Pause;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.UI;
    using Screen = Assets.Scripts.UI.GameUI.Screen;

    public class Settings : Screen, IPause
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitMainMenu;

        private ForegroundAudioService _audioService;

        public event Action MainMenuRequested;

        [Inject]
        private void Construct(
            PauseHandler pauseHandler,
            ForegroundAudioService foregroundAudioService)
        {
            pauseHandler.Add(this);
            _audioService = foregroundAudioService;
        }

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
            _audioService.PlaySound(AudioTypes.Buttons);
            RectTransform.gameObject.SetActive(true);
            CanvasGroup.alpha = 1;
            SetPause(true);
        }

        public override void Close()
        {
            _audioService.PlaySound(AudioTypes.Buttons);
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