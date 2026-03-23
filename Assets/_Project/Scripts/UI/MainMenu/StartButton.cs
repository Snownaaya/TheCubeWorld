namespace Assets.Scripts.UI.MainMenu
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        public event Action ClickButton;

        private void OnEnable() =>
            _startButton.onClick.AddListener(OnStartButtonClicked);

        private void OnDisable() =>
            _startButton.onClick.RemoveListener(OnStartButtonClicked);

        private void OnStartButtonClicked() =>
            ClickButton?.Invoke();
    }
}