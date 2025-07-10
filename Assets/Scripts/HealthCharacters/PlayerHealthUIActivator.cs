using Assets.Scripts.Ground;
using System;
using UnityEngine;

namespace Assets.Scripts.HealthCharacters
{
    public class PlayerHealthUIActivator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private FinalPlatform _finalPlatform;

        private void OnEnable() =>
             _finalPlatform.PlayerReachedFinalPlatform += OnActivedHealth;

        public void OnDisable() =>
            _finalPlatform.PlayerReachedFinalPlatform -= OnActivedHealth;

        private void OnActivedHealth() =>
            _rectTransform.gameObject.SetActive(true);
    }
}