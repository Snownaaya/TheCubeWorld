using Assets.Scripts.Ground;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class PlayerHealthUIActivator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        private FinalPlatform _finalPlatform;

        private void OnEnable() =>
            _finalPlatform.PlayerReachedFinalPlatform += OnActivedHealth;

        private void OnDisable() =>
            _finalPlatform.PlayerReachedFinalPlatform -= OnActivedHealth;

        private void OnActivedHealth(FinalPlatform finalPlatform)
        {
            _finalPlatform = finalPlatform;
            _rectTransform.gameObject.SetActive(true);
        }
    }
}