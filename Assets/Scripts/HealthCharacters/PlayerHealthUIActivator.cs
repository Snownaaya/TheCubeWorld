using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class PlayerHealthUIActivator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private MonoBehaviour _mediatorSource;

        private ILevelProgressMediator _medtior;

        private void Awake() =>
            _medtior = _mediatorSource as ILevelProgressMediator;

        private void OnEnable()
        {
            if (_medtior != null)
                _medtior.PlayerReachedFinalPlatform += OnActivedHealth;
        }

        public void OnDisable()
        {
            if (_medtior != null)
                _medtior.PlayerReachedFinalPlatform -= OnActivedHealth;
        }

        private void OnActivedHealth() =>
            _rectTransform.gameObject.SetActive(true);
    }
}