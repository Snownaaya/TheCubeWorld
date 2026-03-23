namespace Assets.Scripts.UI.FinishedUI
{
    using System;
    using Assets.Scripts.Service.GameMessage;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class AdsCoinButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _adsText;

        private int _currentCoin;   
        private Button _button;

        private GameMessageBus _messageBus;

        public event Action OnClicked;

        private void Awake() => 
            _button = GetComponent<Button>();

        public void Initialize(GameMessageBus messageBus) =>
            _messageBus = messageBus;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            _messageBus.MessageBroker.Publish(_currentCoin);

            OnClicked?.Invoke();

            _button.interactable = false;
        }

        public void UpdateCoinsText(int coins)
        {
            _currentCoin = coins;
            _adsText.text = coins.ToString();
        }
    }
}