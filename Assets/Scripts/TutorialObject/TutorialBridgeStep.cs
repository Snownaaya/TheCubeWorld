using Assets.Scripts.Bridge.Factory;
using UnityEngine;

namespace Assets.Scripts.TutorialObject
{
    public class TutorialBridgeStep : MonoBehaviour
    {
        [SerializeField] private BridgeSpawner _bridgeSpawner;

        private void OnEnable() =>
            _bridgeSpawner.OnSpawned += OnBridgeCompleted;

        private void OnDisable() =>
            _bridgeSpawner.OnSpawned -= OnBridgeCompleted;

        public void OnBridgeCompleted(Bridge.Bridge bridge) =>
            gameObject.SetActive(false);
    }
}