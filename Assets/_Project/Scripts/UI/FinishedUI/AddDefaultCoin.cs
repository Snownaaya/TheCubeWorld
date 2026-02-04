using Assets.Scripts.Service.GameMessage;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.FinishedUI
{
    [RequireComponent(typeof(Button))]
    public class AddDefaultCoin : MonoBehaviour
    {
        private Button _button;
        private GameMessageBus _messageBus;

        private int _coins = 20;

        private void Awake() =>
            _button = GetComponent<Button>();

        public void Initialize(GameMessageBus messageBus) =>
            _messageBus = messageBus;

        private void OnEnable() =>
            _button.onClick.AddListener(OnClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnClick);

        private void OnClick() =>
            _messageBus.MessageBroker.Publish(_coins);
    }
}