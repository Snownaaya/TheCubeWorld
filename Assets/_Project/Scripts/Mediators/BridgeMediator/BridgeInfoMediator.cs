namespace Assets.Project.Scripts.Mediators.BridgeMediator
{
    using Assets.Project.Scripts.Bridge;
    using Assets.Scripts.Bridge;
    using Assets.Scripts.Bridge.Factory;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.TutorialObject;
    using Assets.Scripts.UI.SelectButtons;
    using Reflex.Attributes;
    using UnityEngine;

    public class BridgeInfoMediator : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner _bridgeSpawner;
        [SerializeField] private BridgeChoicePanel _bridgeChoicePanel;
        [SerializeField] private TutorialBridgeStep _tutorialBridgeStep;
        [SerializeField] private Wall _wall;

        private ICharacterHolder _characterHolder;
        private float _closeDelay = 0.2f;

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

        public void OnBridgeCompleted(Bridge bridge)
        {
            _wall.gameObject.SetActive(false);
            _tutorialBridgeStep.ForceHide();
            _bridgeChoicePanel.Close();
        }

        private void OnSetCharacterPosition(Vector3 position)
        {
            if (_tutorialBridgeStep.IsSetPosition(position))
                _bridgeChoicePanel.Open();
            else
                _bridgeChoicePanel.Close();
        }
    }
}