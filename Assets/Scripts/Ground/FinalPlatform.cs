using Assets.Scripts.Camera;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Attack;
using Assets.Scripts.Player.Core;
using Assets.Scripts.Service.GameMessage;
using Reflex.Attributes;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Ground
{
    public class FinalPlatform : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPoint;

        private CompositeDisposable _disposables = new CompositeDisposable();
        private IVirtualCamera _targetBinder;
        private GameMessageBus _messageBus;
        private ICharacterHolder _characterHolder;

        private int _resourceAmount = 10;

        [Inject]
        private void Construct(
            IVirtualCamera targetBinder,
            GameMessageBus gameMessageBus,
            ICharacterHolder character)
        {
            _targetBinder = targetBinder;
            _messageBus = gameMessageBus;
            _characterHolder = character;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Character character))
                PlayerReachedFinalPlatform();
        }

        private void OnDisable() =>
            _disposables.Dispose();

        private void PlayerReachedFinalPlatform()
        {
            if (_characterHolder == null)
                return;

            _targetBinder.ResetTransform();
            _targetBinder.SetTarget(_cameraPoint);
            _targetBinder.ChangeRotate();

            if (HasAllResources() == false)
                _messageBus.MessageBroker.Publish(new NotEnoughResourcesEvent(ResourceTypeSelector.GetRandomTypes()));
        }

        private bool HasAllResources()
        {
            foreach (ResourceTypes type in System.Enum.GetValues(typeof(ResourceTypes)))
            {
                if (_characterHolder.Attacker.ResourceConsumer.HasEnoughTotalResources(_resourceAmount) == false)
                    return false;
            }

            return true;
        }
    }
}