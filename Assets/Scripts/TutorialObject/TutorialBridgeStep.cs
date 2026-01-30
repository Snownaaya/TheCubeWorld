using Assets.Scripts.Bridge.Factory;
using Assets.Scripts.Player.Core;
using Assets.Scripts.PluginYG;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.TutorialObject
{
    public class TutorialBridgeStep : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner _bridgeSpawner;
        [SerializeField] private TextBuildBridge _buildBridgeText;

        private ICharacterHolder _characterHolder;
        private int _distance = 4;
        private bool _isShown;

        [Inject]
        private void Construct(ICharacterHolder characterHolder) =>
            _characterHolder = characterHolder;

        private void OnEnable()
        {
            _bridgeSpawner.OnSpawned += OnBridgeCompleted;
            _characterHolder.Movement.PositionChanged += OnSetCharacterPosition;
        }

        private void OnDisable()
        {
            _bridgeSpawner.OnSpawned -= OnBridgeCompleted;
            _characterHolder.Movement.PositionChanged -= OnSetCharacterPosition;
        }

        public void OnBridgeCompleted(Bridge.Bridge bridge)
        {
            gameObject.SetActive(false);
            _buildBridgeText.Hide();
        }

        private void OnSetCharacterPosition()
        {
            bool isNear = Vector3.Distance(
                _characterHolder.Movement.transform.position,
                transform.position) < _distance;

            if (isNear && _isShown == false)
            {
                _isShown = true;

                _buildBridgeText.SetText(LocalizedText.Get(
                    english: "Bridge Construction",
                    russia: "Постройка моста",
                    turkish: "Köprü inşaatı"));

                _buildBridgeText.Show();
            }
            else if (isNear == false && _isShown)
            {
                _isShown = false;
                _buildBridgeText.Hide();
            }
        }
    }
}