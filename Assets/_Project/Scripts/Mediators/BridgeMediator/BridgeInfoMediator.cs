namespace Assets.Project.Scripts.Mediators.BridgeMediator
{
    using System.Linq;
    using Assets.Project.Scripts.Bridge;
    using Assets.Project.Scripts.UI.SelectButtons;
    using Assets.Scripts.Bridge;
    using Assets.Scripts.Bridge.Factory;
    using Assets.Scripts.Player.Core;
    using Assets.Scripts.TutorialObject;
    using Reflex.Attributes;
    using UnityEngine;

    public class BridgeInfoMediator : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner _bridgeSpawner;
        [SerializeField] private BridgeChoiceStrategy[] _bridgeChoicePanels;
        [SerializeField] private TutorialBridgeStep _tutorialBridgeStep;
        [SerializeField] private Wall _wall;

        private ICharacterHolder _characterHolder;

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

            foreach (var bridgeChoicePanel in _bridgeChoicePanels.OfType<BridgeChoicePanel>())
                bridgeChoicePanel.Destroyed();
        }

        private void OnSetCharacterPosition(Vector3 position)
        {
            foreach (var panel in _bridgeChoicePanels)
            {
                if (_tutorialBridgeStep.IsSetPosition(position))
                    panel.Open();
                else
                    panel.Close();
            }
        }
    }
}