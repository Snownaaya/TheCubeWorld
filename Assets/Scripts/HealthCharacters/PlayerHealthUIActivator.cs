using Assets.Scripts.Interfaces;
using Reflex.Attributes;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class PlayerHealthUIActivator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private ILevelProgressMediator _medtior;

        [Inject]
        private void Construct(ILevelProgressMediator medtior)
        {
            _medtior = medtior;
            _medtior.PlayerReachedFinalPlatform += OnActivedHealth;
        }

        public void OnDisable() =>
            _medtior.PlayerReachedFinalPlatform -= OnActivedHealth;

        private void OnActivedHealth() =>
            _rectTransform.gameObject.SetActive(true);
    }
}